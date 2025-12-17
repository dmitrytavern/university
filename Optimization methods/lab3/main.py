import math

def f(x):
    a = 0.8
    b = 5.5
    return x**4 + a * math.atan(b * x)

def golden_section_method(a, b, epsilon):
    phi = (1 + math.sqrt(5)) / 2
    
    x1 = b - (b - a) / phi
    x2 = a + (b - a) / phi
    
    f1 = f(x1)
    f2 = f(x2)
    
    while abs(b - a) > epsilon:
        if f1 >= f2:
            a = x1
            x1 = x2
            f1 = f2
            x2 = a + (b - a) / phi
            f2 = f(x2)
        else:
            b = x2
            x2 = x1
            f2 = f1
            x1 = b - (b - a) / phi
            f1 = f(x1)
            
    x_opt = (a + b) / 2
    return x_opt, f(x_opt)

start_a = -2.0
start_b = 2.0
eps = 0.0001

print(f"Початковий інтервал: [{start_a}, {start_b}]")
print(f"Точність: {eps}")

x_min, f_min = golden_section_method(start_a, start_b, eps)

print("-" * 30)
print(f"Результат оптимізації (метод золотого перетину):")
print(f"x_opt = {x_min:.6f}")
print(f"f_opt = {f_min:.6f}")