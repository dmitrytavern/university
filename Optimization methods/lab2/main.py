import math

def f(x):
    a = 0.8
    b = 5.5
    return x**4 + a * math.atan(b * x)

def dichotomy_method(a, b, epsilon, delta):
    while (b - a) > epsilon:
        center = (a + b) / 2
        x1 = center - delta
        x2 = center + delta
        
        if f(x1) < f(x2):
            b = x2
        else:
            a = x1
            
    x_opt = (a + b) / 2
    return x_opt, f(x_opt)

start_a = -2.0
start_b = 2.0
eps = 0.0001
delta = 0.00001

print(f"Початковий інтервал: [{start_a}, {start_b}]")
print(f"Точність epsilon: {eps}")
print(f"Delta: {delta}")

x_min, f_min = dichotomy_method(start_a, start_b, eps, delta)

print("-" * 30)
print(f"Результат оптимізації (метод дихотомії):")
print(f"x_opt = {x_min:.6f}")
print(f"f_opt = {f_min:.6f}")