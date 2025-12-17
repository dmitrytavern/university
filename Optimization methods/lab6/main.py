import math

# Допоміжна функція для безпечної експоненти
def safe_exp(val):
    try:
        if val > 700: 
            return 1e100
        return math.exp(val)
    except OverflowError:
        return 1e100

def f(point):
    x, y = point
    a = 26.0
    b = 1.0
    c = 6.25
    d = 0.36
    
    try:
        if abs(x) > 1e100 or abs(y) > 1e100:
            return 1e100
            
        arg = c * x**2 + d * y**2
        return a * x + b * y + safe_exp(arg)
    except OverflowError:
        return 1e100

def get_gradient(point):
    x, y = point
    a = 26.0
    b = 1.0
    c = 6.25
    d = 0.36
    
    try:
        # Якщо координати завеликі, градієнт теж "нескінченний"
        if abs(x) > 1e5 or abs(y) > 1e5:
             return [1e100 * (1 if x>0 else -1), 1e100 * (1 if y>0 else -1)]

        arg = c * x**2 + d * y**2
        exp_val = safe_exp(arg)
        
        df_dx = a + exp_val * (2 * c * x)
        df_dy = b + exp_val * (2 * d * y)
        return [df_dx, df_dy]
    except OverflowError:
        return [1e100, 1e100]

def vector_add(v1, v2):
    return [v1[0] + v2[0], v1[1] + v2[1]]

def vector_scale(v, scalar):
    return [v[0] * scalar, v[1] * scalar]

def dot_product(v1, v2):
    return v1[0] * v2[0] + v1[1] * v2[1]

def minimize_line(point, direction, epsilon=1e-4):
    
    def f_alpha(alpha):
        new_point = vector_add(point, vector_scale(direction, alpha))
        return f(new_point)

    a = 0.0
    b = 1.0 # Початкова спроба кроку
    
    val_a = f_alpha(a)
    
    # 1. Етап "Backtracking": зменшуємо крок, якщо потрапили в "стіну" (переповнення)
    # або якщо функція зростає замість спадання.
    # Оскільки direction - це напрямок спуску, при малому b має виконуватись f(b) < f(a)
    while b > 1e-10:
        val_b = f_alpha(b)
        if val_b < val_a:
            break # Знайшли інтервал, де функція спадає
        b /= 2
    else:
        # Якщо b стало занадто малим і не знайшли спаду (рідкісний випадок)
        return 0.0

    # 2. Етап Золотого перетину
    phi = (1 + math.sqrt(5)) / 2
    x1 = b - (b - a) / phi
    x2 = a + (b - a) / phi
    
    f1 = f_alpha(x1)
    f2 = f_alpha(x2)
    
    iter_count = 0
    while abs(b - a) > epsilon and iter_count < 1000:
        if f1 < f2:
            b = x2
            x2 = x1
            f2 = f1
            x1 = b - (b - a) / phi
            f1 = f_alpha(x1)
        else:
            a = x1
            x1 = x2
            f1 = f2
            x2 = a + (b - a) / phi
            f2 = f_alpha(x2)
        iter_count += 1
            
    return (a + b) / 2

def fletcher_reeves(start_point, epsilon):
    x = start_point
    grad = get_gradient(x)
    
    # d0 = -g0 (напрямок найшвидшого спуску)
    d = vector_scale(grad, -1)
    
    k = 0
    n = 2 
    
    while k < 1000:
        grad_norm = math.sqrt(dot_product(grad, grad))
        
        if grad_norm < epsilon:
            break
            
        # Знаходимо оптимальний крок alpha
        alpha = minimize_line(x, d)
        
        # Обчислюємо нову точку
        x_next = vector_add(x, vector_scale(d, alpha))
        
        # Перевірка на "зависання" (якщо крок занадто малий)
        dist = math.sqrt((x_next[0]-x[0])**2 + (x_next[1]-x[1])**2)
        if dist < 1e-9:
            break

        grad_next = get_gradient(x_next)
        
        grad_next_norm_sq = dot_product(grad_next, grad_next)
        grad_norm_sq = dot_product(grad, grad)
        
        # Захист від ділення на нуль
        if grad_norm_sq == 0:
            break
            
        # Коефіцієнт бета для Флетчера-Рівса
        beta = grad_next_norm_sq / grad_norm_sq
        
        # Оновлення напрямку (рестарт методу кожні N кроків)
        if (k + 1) % n == 0:
             d_next = vector_scale(grad_next, -1)
        else:
             # d_next = -grad_next + beta * d_prev
             term1 = vector_scale(grad_next, -1)
             term2 = vector_scale(d, beta)
             d_next = vector_add(term1, term2)
        
        x = x_next
        grad = grad_next
        d = d_next
        k += 1
        
    return x, f(x), k

x0 = [0.0, 0.0]
eps = 0.0001

print(f"Початкова точка: {x0}")
print(f"Точність: {eps}")

res_x, res_f, iterations = fletcher_reeves(x0, eps)

print("-" * 30)
print(f"Результат (Метод Флетчера-Рівса):")
print(f"Кількість ітерацій: {iterations}")
print(f"x_opt = [{res_x[0]:.6f}, {res_x[1]:.6f}]")
print(f"f_opt = {res_f:.6f}")