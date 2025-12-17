#include <iostream>
#include <vector>
#include <string>
#include <thread>
#include <mutex>
#include <chrono>

using namespace std;

// Спільні ресурси
vector<string> spaceLog;
mutex mtx; // М'ютекс для захисту даних

// Функція запису (додає дані)
void Writer(int count, bool useMutex) {
    for (int i = 0; i < count; ++i) {
        if (useMutex) mtx.lock(); // Блокуємо доступ

        // Критична секція
        string entry = "Корабель #" + to_string(i + 1) + " прибув.";
        spaceLog.push_back(entry);

        if (useMutex) mtx.unlock(); // Розблокуємо доступ
        
        this_thread::sleep_for(10ms); // Маленька затримка для провокації конфлікту
    }
}

// Функція читання (читає дані)
void Reader(bool useMutex) {
    // Читач працює трохи довше, намагаючись прочитати дані під час запису
    for (int i = 0; i < 5; ++i) {
        if (useMutex) mtx.lock();

        cout << "\n--- Читання журналу (" << spaceLog.size() << " записiв) ---" << endl;
        for (const auto& entry : spaceLog) {
            // Просто імітуємо обробку, вивід може "ламатися" без м'ютекса
           cout << entry << " ";
        }
        cout << endl;

        if (useMutex) mtx.unlock();
        this_thread::sleep_for(15ms);
    }
}

// 3.1 Синхронний режим
void RunSync() {
    cout << "=== Sync Mode ===" << endl;
    spaceLog.clear();
    
    Writer(5, false);
    Reader(false);
}

// 3.2 Небезпечний режим (без м'ютекса)
void RunUnsafe() {
    cout << "=== Unsafe Async Mode (Race Condition) ===" << endl;
    spaceLog.clear();

    thread t1(Writer, 10, false);
    thread t2(Reader, false);

    t1.join();
    t2.join();
    cout << "\nКiнцевий розмiр журналу: " << spaceLog.size() << endl;
}

// 3.3 Безпечний режим (з м'ютексом)
void RunSafe() {
    cout << "=== Safe Async Mode (Mutex) ===" << endl;
    spaceLog.clear();

    thread t1(Writer, 10, true);
    thread t2(Reader, true);

    t1.join();
    t2.join();
    cout << "\nКiнцевий розмiр журналу: " << spaceLog.size() << endl;
}

int main() {
    int choice;
    cout << "Лабораторна робота No6. Оберiть режим:" << endl;
    cout << "1. Синхронний" << endl;
    cout << "2. Асинхронний, небезпечний (може впасти або вивести смiття)" << endl;
    cout << "3. Асинхронний, безпечний (mutex)" << endl;
    cout << "-> ";
    cin >> choice;

    try {
        switch (choice) {
            case 1: RunSync(); break;
            case 2: RunUnsafe(); break;
            case 3: RunSafe(); break;
        }
    } catch (const exception& e) {
        cout << "\n[ПОМИЛКА] Спіймано виключення (типово для Unsafe режиму): " << e.what() << endl;
    }

    return 0;
}