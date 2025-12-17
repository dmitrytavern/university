def hamming_encode(data):
    m = len(data)
    r = 0
    while (2**r < m + r + 1):
        r += 1
    
    n = m + r
    code = ['0'] * (n + 1)
    
    j = 0
    for i in range(1, n + 1):
        if not (i & (i - 1) == 0):
            code[i] = data[j]
            j += 1

    for i in range(r):
        pos = 2**i
        val = 0
        for k in range(1, n + 1):
            if k & pos:
                val ^= int(code[k])
        code[pos] = str(val)
        
    return ''.join(code[1:])

data_word = "1100100100111100"
syndrome_vector_given = "10001"  # Вектор синдромів з умови
error_bit_pos_given = 10         # Номер біта з помилкою з умови

print("--- ЗАВДАННЯ 2: КОД ХЕМІНГА ---")

encoded_msg = hamming_encode(data_word)
print(f"1. Кодування слова: {data_word}")
print(f"   Результат (Код Хемінга): {encoded_msg}")
print(f"   Довжина: {len(encoded_msg)} біт (Контрольних: {len(encoded_msg)-len(data_word)})")

error_pos = int(syndrome_vector_given, 2)
print(f"\n2. Пошук біта з помилкою за синдромом '{syndrome_vector_given}':")
print(f"   Помилка у біті №: {error_pos}")

calculated_syndrome = format(error_bit_pos_given, '05b')
print(f"\n3. Пошук вектора синдромів для помилки у біті {error_bit_pos_given}:")
print(f"   Вектор синдромів: {calculated_syndrome}")