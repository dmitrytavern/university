import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.decomposition import PCA
from sklearn.preprocessing import StandardScaler

data = {
    'Area': [50, 65, 75, 80, 90, 100, 110, 120],
    'Price': [120, 150, 160, 180, 200, 210, 225, 250]
}
df = pd.DataFrame(data)

scaler = StandardScaler()
X_scaled = scaler.fit_transform(df)

pca = PCA(n_components=2)
principal_components = pca.fit_transform(X_scaled)

pca_df = pd.DataFrame(data=principal_components, columns=['PC1', 'PC2'])

print("--- Результати Завдання 1 (Нерухомість) ---")
print(f"Пояснена дисперсія (Explained Variance): {pca.explained_variance_ratio_}")
print(f"Власні вектори (компоненти):\n{pca.components_}")

plt.figure(figsize=(8, 6))
plt.scatter(pca_df['PC1'], pca_df['PC2'], color='blue', label='Дані')
plt.title('PCA: Дані про нерухомість у просторі головних компонент')
plt.xlabel(f'Головна компонента 1 ({pca.explained_variance_ratio_[0]:.2%} дисперсії)')
plt.ylabel(f'Головна компонента 2 ({pca.explained_variance_ratio_[1]:.2%} дисперсії)')

coeff = np.transpose(pca.components_[0:2, :])
n = coeff.shape[0]
labels = ['Area', 'Price']
for i in range(n):
    plt.arrow(0, 0, coeff[i,0]*2, coeff[i,1]*2, color='r', alpha=0.5)
    plt.text(coeff[i,0]*2.2, coeff[i,1]*2.2, labels[i], color='g', ha='center', va='center')

plt.grid()
plt.axhline(0, color='black', linewidth=0.5)
plt.axvline(0, color='black', linewidth=0.5)
plt.savefig('regression_plot.png')