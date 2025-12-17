import math

def f(x):
    a = 0.8
    b = 5.5
    return x**4 + a * math.atan(b * x)

def fibonacci_method(a, b, epsilon):
    # Генерація чисел Фібоначчі
    fibs = [1, 1]
    while True:
        next_fib = fibs[-1] + fibs[-2]
        fibs.append(next_fib)
        if next_fib > (b - a) / epsilon:
            break
            
    n = len(fibs) - 1
    
    x1 = a + (fibs[n-2] / fibs[n]) * (b - a)
    x2 = a + (fibs[n-1] / fibs[n]) * (b - a)
    
    f1 = f(x1)
    f2 = f(x2)
    
    # Ітераційний процес
    for k in range(1, n - 1):
        if f1 > f2:
            a = x1
            x1 = x2
            f1 = f2
            x2 = a + (fibs[n-k-1] / fibs[n-k]) * (b - a)
            f2 = f(x2)
        else:
            b = x2
            x2 = x1
            f2 = f1
            x1 = a + (fibs[n-k-2] / fibs[n-k]) * (b - a)
            f1 = f(x1)
            
    # Остання ітерація з малим зсувом для розрізнення точок
    x2 = x1 + epsilon
    if f(x1) > f(x2):
        a = x1
    else:
        b = x2
        
    x_opt = (a + b) / 2
    return x_opt, f(x_opt)

start_a = -2.0
start_b = 2.0
eps = 0.0001

print(f"Початковий інтервал: [{start_a}, {start_b}]")
print(f"Точність: {eps}")

x_min, f_min = fibonacci_method(start_a, start_b, eps)

print("-" * 30)
print(f"Результат оптимізації (метод Фібоначчі):")
print(f"x_opt = {x_min:.6f}")
print(f"f_opt = {f_min:.6f}")