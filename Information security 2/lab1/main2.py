alphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ"
letter_to_index = {letter: idx + 1 for idx, letter in enumerate(alphabet)}

P = 73
g = 6
X = 8
k_values = [18, 10, 13]
word = "ЕКЗАЛЬТАЦІЯ"

Y = pow(g, X, P)

print(f"--- Результати Ель-Гамаля (Варіант 11) ---")
print(f"Просте число P={P}")
print(f"Генератор g={g}")
print(f"Секретний ключ X={X}")
print(f"Відкритий ключ Y={Y}")
print(f"Числа k (циклічно): {k_values}")
print(f"\nШифрування слова: {word}")
print("-" * 55)
print(f"{'Літера':<8} {'Індекс':<8} {'k':<5} {'a = g^k':<10} {'b = Y^k*M':<10} {'Шифр (a,b)'}")
print("-" * 55)

encrypted_pairs = []
k_idx = 0

for char in word:
    if char in letter_to_index:
        m = letter_to_index[char]
        k = k_values[k_idx % len(k_values)]
        k_idx += 1
        
        a = pow(g, k, P)
        b = (pow(Y, k, P) * m) % P
        
        encrypted_pairs.append((a, b))
        print(f"{char:<8} {m:<8} {k:<5} {a:<10} {b:<10} ({a}, {b})")

print("-" * 55)
print(f"Результат: {encrypted_pairs}")