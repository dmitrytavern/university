def extended_gcd(a, b):
    if a == 0:
        return b, 0, 1
    else:
        g, y, x = extended_gcd(b % a, a)
        return g, x - (b // a) * y, y

def modinv(a, m):
    g, x, y = extended_gcd(a, m)
    if g != 1:
        raise Exception('Modular inverse does not exist')
    else:
        return x % m

alphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ"
letter_to_index = {letter: idx + 1 for idx, letter in enumerate(alphabet)}

p = 73
q = 29
e = 11
word = "ЕКЗАЛЬТАЦІЯ"

n = p * q
phi = (p - 1) * (q - 1)
d = modinv(e, phi)

print(f"--- Результати RSA (Варіант 11) ---")
print(f"Прості числа: p={p}, q={q}")
print(f"Модуль n={n}")
print(f"Функція Ейлера phi={phi}")
print(f"Відкрита експонента e={e}")
print(f"Секретна експонента d={d}")
print(f"\nШифрування слова: {word}")
print("-" * 45)
print(f"{'Літера':<10} {'Індекс (M)':<15} {'Шифротекст (C)'}")
print("-" * 45)

encrypted_msg = []

for char in word:
    if char in letter_to_index:
        m = letter_to_index[char]
        c = pow(m, e, n)
        encrypted_msg.append(c)
        print(f"{char:<10} {m:<15} {c}")

print("-" * 45)
print(f"Результат: {encrypted_msg}")