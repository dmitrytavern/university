import cv2
from sklearn.decomposition import PCA
import matplotlib.pyplot as plt
import numpy as np

def process_image_pca(image_path):
    try:
        img = cv2.imread(image_path)
        img = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
    except:
        print("Файл не знайдено, генеруємо тестове зображення...")
        img = np.zeros((100, 100, 3), dtype=np.uint8)
        for i in range(100):
            for j in range(100):
                img[i, j] = [i*2, j*2, (i+j)]

    h, w, c = img.shape
    
    img_reshaped = img.reshape(-1, 3)

    img_normalized = img_reshaped / 255.0

    pca = PCA(n_components=3)
    img_pca = pca.fit_transform(img_normalized)

    print("\n--- Результати Завдання 2 (Зображення) ---")
    print(f"Пояснена дисперсія каналів RGB: {pca.explained_variance_ratio_}")

    pc1_img = img_pca[:, 0].reshape(h, w)
    pc2_img = img_pca[:, 1].reshape(h, w)
    pc3_img = img_pca[:, 2].reshape(h, w)

    fig, axes = plt.subplots(1, 4, figsize=(16, 4))
    
    axes[0].imshow(img)
    axes[0].set_title("Оригінал")
    axes[0].axis('off')

    axes[1].imshow(pc1_img, cmap='gray')
    axes[1].set_title(f"PC1 (Контраст/Яскравість)\n{pca.explained_variance_ratio_[0]:.1%} інфо")
    axes[1].axis('off')

    axes[2].imshow(pc2_img, cmap='gray')
    axes[2].set_title(f"PC2 (Колір 1)\n{pca.explained_variance_ratio_[1]:.1%} інфо")
    axes[2].axis('off')

    axes[3].imshow(pc3_img, cmap='gray')
    axes[3].set_title(f"PC3 (Колір 2)\n{pca.explained_variance_ratio_[2]:.1%} інфо")
    axes[3].axis('off')

    plt.savefig('my_image_plot.png')

process_image_pca('my_image.bmp')