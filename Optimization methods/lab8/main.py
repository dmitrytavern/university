import math

# --- Безпечні математичні функції (з попередніх робіт) ---
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

# --- Векторні операції ---
def vec_add(v1, v2): return [x + y for x, y in zip(v1, v2)]
def vec_scale(v, s): return [x * s for x in v]
def dot(v1, v2): return sum(x * y for x, y in zip(v1, v2))
def vec_norm(v): return math.sqrt(dot(v, v))

def mat_mult_vec(M, v):
    # Множення рядків матриці на скаляри вектора
    res = [0.0] * len(M[0])
    for i in range(len(M)): # по векторах базису
        for j in range(len(res)):
            res[j] += M[i][j] * v[i]
    return res

# --- Метод Розенброка ---
def rosenbrock_method(start_point, epsilon):
    n = len(start_point)
    x = start_point[:]
    
    # Початкова система координат (одинична матриця)
    # V[i] - це i-й вектор напрямку
    V = [[1.0 if i == j else 0.0 for j in range(n)] for i in range(n)]
    
    # Початкові довжини кроків
    steps = [0.1] * n
    
    alpha = 3.0
    beta = 0.5
    
    iterations = 0
    
    while iterations < 1000:
        start_stage_x = x[:]
        
        # Масиви для відстеження успіхів/невдач на цьому етапі
        # d - сумарний зсув по кожному напрямку
        d = [0.0] * n 
        
        # Прапорці, що по і-му напрямку був хоча б один успіх і одна невдача
        has_success = [False] * n
        has_fail = [False] * n
        
        # Цикл етапу (поки не виконається умова Розенброка по всіх осях)
        while not (all(has_success) and all(has_fail)):
            
            # Спроба кроку по кожному напрямку
            for i in range(n):
                # Поточна точка + крок * вектор напрямку
                move = vec_scale(V[i], steps[i])
                x_try = vec_add(x, move)
                
                f_curr = f(x)
                f_try = f(x_try)
                
                if f_try < f_curr:
                    # Успіх
                    x = x_try
                    d[i] += steps[i]
                    steps[i] *= alpha
                    has_success[i] = True
                else:
                    # Невдача
                    steps[i] *= -beta
                    has_fail[i] = True
            
            # Перевірка на зациклення всередині етапу (якщо кроки стали мізерними)
            if max([abs(s) for s in steps]) < 1e-12:
                break
        
        # Перевірка умови зупинки (зміна координат за етап мала)
        shift_norm = vec_norm(vec_add(x, vec_scale(start_stage_x, -1)))
        if shift_norm < epsilon:
            break
            
        # --- Процедура Грама-Шмідта (Обертання осей) ---
        # Сортуємо напрямки: найбільш успішні мають бути першими
        # Але в класичному Розенброку просто будуємо нові вектори A
        
        # Обчислення векторів A
        A = []
        for i in range(n):
            # A_i - сума всіх зсувів від i до N
            vec_sum = [0.0] * n
            for j in range(i, n):
                # d[j] * V[j]
                v_scaled = vec_scale(V[j], d[j])
                vec_sum = vec_add(vec_sum, v_scaled)
            A.append(vec_sum)
            
        # Ортогоналізація
        new_V = [[0.0]*n for _ in range(n)]
        
        for i in range(n):
            # B_i = A_i - sum(proj A_i on new_V_k)
            B = A[i][:]
            for k in range(i):
                # proj = (A[i] . new_V[k]) * new_V[k]
                coeff = dot(A[i], new_V[k])
                sub = vec_scale(new_V[k], coeff)
                B = vec_add(B, vec_scale(sub, -1))
            
            # Нормування
            norm_B = vec_norm(B)
            if norm_B > 0:
                new_V[i] = vec_scale(B, 1.0 / norm_B)
            else:
                # Якщо вектор нульовий, залишаємо старий (або беремо будь-який ортогональний)
                new_V[i] = V[i]
                
        V = new_V
        # Скидання кроків для нової системи координат
        steps = [0.1] * n
        iterations += 1
        
    return x, f(x), iterations

x0 = [0.0, 0.0]
eps = 0.0001

print(f"Початкова точка: {x0}")
print(f"Точність: {eps}")

res_x, res_f, iterations = rosenbrock_method(x0, eps)

print("-" * 30)
print(f"Результат (Метод Розенброка):")
print(f"Кількість зовнішніх ітерацій (поворотів): {iterations}")
print(f"x_opt = [{res_x[0]:.6f}, {res_x[1]:.6f}]")
print(f"f_opt = {res_f:.6f}")