import math

def f(x):
    a = 0.8
    b = 5.5
    return x**4 + a * math.atan(b * x)

def half_division_method(a, b, epsilon):
    xm = (a + b) / 2
    
    while True:
        L = b - a
        if abs(L) < epsilon:
            break
            
        x1 = a + L / 4
        x2 = b - L / 4
        
        fx1 = f(x1)
        fxm = f(xm)
        fx2 = f(x2)
        
        if fx1 < fxm:
            b = xm
            xm = x1
        else:
            if fx2 < fxm:
                a = xm
                xm = x2
            else:
                a = x1
                b = x2
                
    return xm, f(xm)

start_a = -2.0
start_b = 2.0
eps = 0.0001

print(f"Початковий інтервал: [{start_a}, {start_b}]")
print(f"Точність: {eps}")

x_min, f_min = half_division_method(start_a, start_b, eps)

print("-" * 30)
print(f"Результат оптимізації:")
print(f"x_opt = {x_min:.6f}")
print(f"f_opt = {f_min:.6f}")