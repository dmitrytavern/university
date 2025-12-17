def xor(a, b):
    result = []
    for i in range(1, len(b)):
        if a[i] == b[i]:
            result.append('0')
        else:
            result.append('1')
    return ''.join(result)

def mod2div(dividend, divisor):
    pick = len(divisor)
    tmp = dividend[0: pick]
    
    while pick < len(dividend):
        if tmp[0] == '1':
            tmp = xor(divisor, tmp) + dividend[pick]
        else:
            tmp = xor('0'*pick, tmp) + dividend[pick]
        pick += 1
        
    if tmp[0] == '1':
        tmp = xor(divisor, tmp)
    else:
        tmp = xor('0'*pick, tmp)
        
    return tmp

def encode_cyclic(data, poly):
    appended_data = data + '0' * (len(poly) - 1)
    remainder = mod2div(appended_data, poly)
    return data + remainder

word_to_encode = "10011"
poly_encode = "11001" # X^4 + X^3 + 1

received_code = "111001101"
poly_decode = "10011" # X^4 + X + 1

print("--- ЗАВДАННЯ 1: ЦИКЛІЧНІ КОДИ (Оновлено) ---")

encoded_msg = encode_cyclic(word_to_encode, poly_encode)
print(f"1. Кодування слова: {word_to_encode}")
print(f"   Породжуючий поліном: {poly_encode}")
print(f"   Результат кодування: {encoded_msg}")

print(f"\n2. Пошук помилки у коді: {received_code}")
print(f"   Поліном для перевірки: {poly_decode}")

syndrome = mod2div(received_code, poly_decode)
print(f"   Обчислений синдром: {syndrome}")

n = len(received_code)
error_found = False

for i in range(n):
    e_vector_list = ['0'] * n
    e_vector_list[i] = '1'
    e_vector = "".join(e_vector_list)
    
    current_syndrome = mod2div(e_vector, poly_decode)
    
    if current_syndrome == syndrome:
        print(f"   Помилку знайдено у біті з індексом: {i} (біт №{i+1} зліва)")
        
        fixed_list = list(received_code)
        fixed_list[i] = '1' if fixed_list[i] == '0' else '0'
        print(f"   Виправлений код: {''.join(fixed_list)}")
        error_found = True
        break

if not error_found:
    print("   Помилку не знайдено або вона не є одинарною.")