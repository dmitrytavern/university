import math

def f(x, y):
    a = 26.0
    b = 1.0
    c = 6.25
    d = 0.36
    # Обчислення значення функції
    return a * x + b * y + math.exp(c * x**2 + d * y**2)

def get_gradient(x, y):
    a = 26.0
    b = 1.0
    c = 6.25
    d = 0.36
    exp_val = math.exp(c * x**2 + d * y**2)
    
    # Часткова похідна по x
    df_dx = a + exp_val * (2 * c * x)
    # Часткова похідна по y
    df_dy = b + exp_val * (2 * d * y)
    
    return df_dx, df_dy

def steepest_descent(start_x, start_y, start_lam, epsilon):
    x = start_x
    y = start_y
    lam = start_lam
    k = 1 # номер ітерації
    
    while True:
        # 1. Обчислення значення функції та градієнта
        current_f = f(x, y)
        grad_x, grad_y = get_gradient(x, y)
        
        # 2. Обчислення норми градієнта
        grad_norm = math.sqrt(grad_x**2 + grad_y**2)
        
        # 3. Перевірка умови зупинки
        if grad_norm < epsilon:
            break
            
        # 4. Пошук нового положення (регулювання кроку)
        while True:
            # Рух в напрямку антиградієнта
            x_new = x - lam * grad_x
            y_new = y - lam * grad_y
            
            f_new = f(x_new, y_new)
            
            # Якщо крок успішний (значення функції зменшилось)
            if f_new < current_f:
                x = x_new
                y = y_new
                break
            else:
                # Якщо ні - зменшуємо крок вдвічі
                lam = lam / 2
        
        k += 1
        
    return x, y, f(x, y), k

x0, y0 = 0.0, 0.0
lam0 = 0.1
eps = 0.0001

print(f"Початкова точка: ({x0}, {y0})")
print(f"Початковий крок: {lam0}")

res_x, res_y, res_f, iterations = steepest_descent(x0, y0, lam0, eps)

print("-" * 30)
print(f"Результат оптимізації (Метод найшвидшого спуску):")
print(f"Кількість ітерацій: {iterations}")
print(f"x_opt = {res_x:.6f}")
print(f"y_opt = {res_y:.6f}")
print(f"f_opt = {res_f:.6f}")