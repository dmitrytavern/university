import numpy as np
import pandas as pd
import matplotlib.pyplot as plt

data = {
  'Area_X': [50, 65, 75, 80, 90, 100, 110, 120],  # Площа (м2)
  'Price_Y': [120, 150, 160, 180, 200, 210, 225, 250] # Ціна (тис. дол)
}
df = pd.DataFrame(data)

X = df['Area_X'].values
Y = df['Price_Y'].values

X_mean = np.mean(X)
Y_mean = np.mean(Y)

numerator = np.sum((X - X_mean) * (Y - Y_mean))
denominator = np.sum((X - X_mean) ** 2)
beta_1 = numerator / denominator

beta_0 = Y_mean - beta_1 * X_mean

print(f"Рівняння регресії: Y = {beta_0:.2f} + {beta_1:.2f} * X")

area_to_predict = 85
predicted_price = beta_0 + beta_1 * area_to_predict
print(f"Прогнозована ціна для будинку {area_to_predict} м2: {predicted_price:.2f} тис. дол")

Y_pred = beta_0 + beta_1 * X

SSE = np.sum((Y - Y_pred) ** 2)
SST = np.sum((Y - Y_mean) ** 2)
R2 = 1 - (SSE / SST)
print(f"Коефіцієнт детермінації (R^2): {R2:.4f}")

plt.figure(figsize=(10, 6))
plt.scatter(X, Y, color='blue', label='Фактичні дані')
plt.plot(X, Y_pred, color='red', linewidth=2, label='Лінія регресії')
plt.scatter(area_to_predict, predicted_price, color='green', s=100, zorder=5, label=f'Прогноз ({area_to_predict} м2)')

plt.title('Лінійна регресія: Залежність ціни від площі')
plt.xlabel('Площа (м2)')
plt.ylabel('Ціна (тис. дол)')
plt.legend()
plt.grid(True)
plt.savefig('regression_plot.png')