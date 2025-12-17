import math
from collections import Counter

class Node:
    def __init__(self, char, prob):
        self.char = char      # Символ
        self.prob = prob      # Ймовірність
        self.code = ""        # Код

def shannon_fano_split(nodes):
    if len(nodes) <= 1:
        return
    
    nodes.sort(key=lambda x: x.prob, reverse=True)
    
    total_prob = sum(n.prob for n in nodes)
    half_prob = total_prob / 2
    
    current_prob = 0
    split_idx = 0
    min_diff = float('inf')
    
    for i in range(len(nodes) - 1):
        current_prob += nodes[i].prob
        diff = abs(half_prob - current_prob)
        if diff < min_diff:
            min_diff = diff
            split_idx = i
        else:
            break
    
    left_part = nodes[:split_idx+1]
    right_part = nodes[split_idx+1:]
    
    for node in left_part:
        node.code += "0"
    for node in right_part:
        node.code += "1"
        
    shannon_fano_split(left_part)
    shannon_fano_split(right_part)

def simple_binary_encode(text):
    binary_str = ""
    try:
        encoded_bytes = text.encode('cp1251')
        for byte in encoded_bytes:
            binary_str += format(byte, '08b')
    except UnicodeEncodeError:
        print("Помилка кодування у CP1251. Використовуємо UTF-8 (може бути більше 8 біт/символ).")
        encoded_bytes = text.encode('utf-8')
        for byte in encoded_bytes:
            binary_str += format(byte, '08b')
            
    return binary_str

word = "інтенсифікація"

print(f"--- ЗАВДАННЯ 3: КОД ШЕННОНА-ФАНО (Варіант 11) ---")
print(f"Слово для кодування: '{word}'")
print(f"Кількість символів: {len(word)}")

freqs = Counter(word)
total_chars = len(word)
nodes = []

print("\n1. Таблиця частот та ймовірностей:")
print(f"{'Символ':<8} {'Частота':<10} {'Ймовірність':<10}")
for char, count in freqs.most_common():
    prob = count / total_chars
    nodes.append(Node(char, prob))
    print(f"'{char}':     {count:<10} {prob:.4f}")

shannon_fano_split(nodes)

sf_code_map = {node.char: node.code for node in nodes}

sf_encoded_str = "".join([sf_code_map[char] for char in word])

bin_encoded_str = simple_binary_encode(word)

nodes.sort(key=lambda x: x.prob, reverse=True) # Сортуємо для виводу таблиці кодів
print("\n2. Отримані коди Шеннона-Фано:")
print(f"{'Символ':<8} {'Код':<10} {'Довжина (біт)':<15}")
for node in nodes:
    print(f"'{node.char}':     {node.code:<10} {len(node.code):<15}")

print("\n3. Порівняння результатів:")

print(f"\nА) Метод Шеннона-Фано:")
print(f"   Закодований рядок: {sf_encoded_str}")
print(f"   Довжина коду: {len(sf_encoded_str)} біт")

print(f"\nБ) Звичайний двійковий формат (8 біт/символ):")
print(f"   Закодований рядок: {bin_encoded_str}")
print(f"   Довжина коду: {len(bin_encoded_str)} біт")

len_sf = len(sf_encoded_str)
len_bin = len(bin_encoded_str)
compression_ratio = (1 - len_sf / len_bin) * 100

print(f"\n4. Висновок:")
print(f"   Код Шеннона-Фано коротший на {len_bin - len_sf} біт.")
print(f"   Коефіцієнт стиснення: {compression_ratio:.2f}%")