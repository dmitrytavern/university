import math

# --- Допоміжні функції (безпечна математика з Лаб 6) ---
def safe_exp(val):
    try:
        if val > 700: return 1e100
        return math.exp(val)
    except OverflowError:
        return 1e100

def f(point):
    x, y = point
    a, b = 26.0, 1.0
    c, d = 6.25, 0.36
    try:
        if abs(x) > 1e100 or abs(y) > 1e100: return 1e100
        arg = c * x**2 + d * y**2
        return a * x + b * y + safe_exp(arg)
    except OverflowError: return 1e100

def get_gradient(point):
    x, y = point
    a, b = 26.0, 1.0
    c, d = 6.25, 0.36
    try:
        if abs(x) > 1e5 or abs(y) > 1e5: return [1e100, 1e100]
        arg = c * x**2 + d * y**2
        exp_val = safe_exp(arg)
        return [a + exp_val * (2 * c * x), b + exp_val * (2 * d * y)]
    except OverflowError: return [1e100, 1e100]

# --- Матричні операції ---
def vec_add(v1, v2): return [x + y for x, y in zip(v1, v2)]
def vec_sub(v1, v2): return [x - y for x, y in zip(v1, v2)]
def vec_scale(v, s): return [x * s for x in v]
def dot(v1, v2): return sum(x * y for x, y in zip(v1, v2))

def mat_vec_mult(H, v):
    # Множення матриці 2x2 на вектор 2x1
    res = [0.0] * len(v)
    for i in range(len(v)):
        res[i] = dot(H[i], v)
    return res

def outer_product(v1, v2):
    # Зовнішній добуток векторів (результат - матриця)
    n = len(v1)
    res = [[0.0] * n for _ in range(n)]
    for i in range(n):
        for j in range(n):
            res[i][j] = v1[i] * v2[j]
    return res

def mat_add(A, B):
    n = len(A)
    return [[A[i][j] + B[i][j] for j in range(n)] for i in range(n)]

def mat_sub(A, B):
    n = len(A)
    return [[A[i][j] - B[i][j] for j in range(n)] for i in range(n)]

# --- Одновимірний пошук (з Лаб 6) ---
def minimize_line(point, direction, epsilon=1e-4):
    def f_alpha(alpha):
        return f(vec_add(point, vec_scale(direction, alpha)))
    
    a, b = 0.0, 1.0
    # Backtracking для пошуку валідного початкового інтервалу
    while b > 1e-10:
        if f_alpha(b) < f_alpha(a): break
        b /= 2
    else: return 0.0

    phi = (1 + math.sqrt(5)) / 2
    x1, x2 = b - (b - a) / phi, a + (b - a) / phi
    f1, f2 = f_alpha(x1), f_alpha(x2)
    
    for _ in range(100): # Ліміт ітерацій
        if abs(b - a) < epsilon: break
        if f1 < f2:
            b, x2, f2 = x2, x1, f1
            x1 = b - (b - a) / phi
            f1 = f_alpha(x1)
        else:
            a, x1, f1 = x1, x2, f2
            x2 = a + (b - a) / phi
            f2 = f_alpha(x2)
    return (a + b) / 2

# --- Метод DFP ---
def dfp_method(start_point, epsilon):
    n = len(start_point)
    x = start_point[:]
    # Початкова матриця H = одинична матриця [cite: 639, 640]
    H = [[1.0 if i == j else 0.0 for j in range(n)] for i in range(n)]
    
    grad = get_gradient(x)
    k = 0
    
    while k < 1000:
        grad_norm = math.sqrt(dot(grad, grad))
        if grad_norm < epsilon: break
        
        # 1. Визначення напрямку: S = -H * grad [cite: 644] (S_i в формулі 7.2)
        # Враховуючи знак мінус:
        neg_grad = vec_scale(grad, -1)
        S = mat_vec_mult(H, neg_grad)
        
        # 2. Одновимірний пошук кроку lambda [cite: 642]
        lam = minimize_line(x, S)
        
        # 3. Оновлення точки
        delta_x = vec_scale(S, lam)
        x_new = vec_add(x, delta_x)
        
        # Перевірка на малий крок
        if math.sqrt(dot(delta_x, delta_x)) < 1e-9: break
            
        grad_new = get_gradient(x_new)
        delta_g = vec_sub(grad_new, grad) # delta G 
        
        # 4. Оновлення матриці H за формулами (7.3 - 7.5)
        # H_new = H + A - B
        
        # Чисельник і знаменник для матриці A [cite: 652]
        # A = (dx * dx^T) / (dx^T * dg)
        dx_dot_dg = dot(delta_x, delta_g)
        
        if abs(dx_dot_dg) > 1e-10: # Захист від ділення на 0
            term_A = outer_product(delta_x, delta_x)
            term_A = [[val / dx_dot_dg for val in row] for row in term_A]
            
            # Чисельник і знаменник для матриці B [cite: 652]
            # B = (H * dg) * (H * dg)^T / (dg^T * H * dg)
            H_dg = mat_vec_mult(H, delta_g)
            dg_H_dg = dot(delta_g, H_dg)
            
            term_B = outer_product(H_dg, H_dg)
            term_B = [[val / dg_H_dg for val in row] for row in term_B]
            
            # H = H + A - B
            H = mat_sub(mat_add(H, term_A), term_B)
        
        x = x_new
        grad = grad_new
        k += 1
        
    return x, f(x), k

x0 = [0.0, 0.0]
eps = 0.0001

print(f"Початкова точка: {x0}")
print(f"Точність: {eps}")



res_x, res_f, iterations = dfp_method(x0, eps)

print("-" * 30)
print(f"Результат (Метод Девідона-Флетчера-Пауела):")
print(f"Кількість ітерацій: {iterations}")
print(f"x_opt = [{res_x[0]:.6f}, {res_x[1]:.6f}]")
print(f"f_opt = {res_f:.6f}")