#include <iostream>
#include <thread>
#include <mutex>
#include <chrono>
#include <string>

using namespace std;

recursive_mutex r_mtx;

// Функція сканування (рекурсивна)
// useMutex: чи використовувати захист
void ScanSector(int depth, int maxDepth, bool useMutex) {
    if (depth > maxDepth) return;

    // Блокуємо м'ютекс, якщо режим Safe
    // У рекурсії потік може захопити цей м'ютекс N разів
    if (useMutex) r_mtx.lock();

    // Критична секція (вивід у консоль)
    // Емуляція відступів для наочності вкладеності
    string indent(depth * 2, ' ');
    cout << indent << "[ID:" << this_thread::get_id() << "] Сканування рiвня " << depth << endl;

    // Імітація роботи
    this_thread::sleep_for(100ms);

    // Рекурсивний виклик
    ScanSector(depth + 1, maxDepth, useMutex);

    if (useMutex) r_mtx.unlock();
}

// 3.1 Синхронний режим
void RunSync() {
    cout << "=== Sync Mode ===" << endl;
    ScanSector(1, 3, false);
    ScanSector(1, 3, false);
}

// 3.2 Асинхронний режим (без м'ютекса)
void RunUnsafe() {
    cout << "=== Unsafe Async Mode (Messy Output) ===" << endl;
    // Запускаємо два потоки, які одночасно пишуть у консоль
    thread t1(ScanSector, 1, 4, false);
    thread t2(ScanSector, 1, 4, false);

    t1.join();
    t2.join();
}

// 3.3 Асинхронний режим (з рекурсивним м'ютексом)
void RunSafe() {
    cout << "=== Safe Async Mode (Recursive Mutex) ===" << endl;
    // Запускаємо два потоки із захистом
    // Один потік захопить м'ютекс і триматиме його крізь УСІ рівні рекурсії
    // Інший потік чекатиме, поки перший повністю не вийде з рекурсії (всі unlock)
    thread t1(ScanSector, 1, 4, true);
    thread t2(ScanSector, 1, 4, true);

    t1.join();
    t2.join();
}

int main() {
    int choice;
    cout << "Лабораторна робота No7. Оберiть режим:" << endl;
    cout << "1. Синхронний" << endl;
    cout << "2. Асинхронний, небезпечний" << endl;
    cout << "3. Асинхронний, безпечний (Recursive Mutex)" << endl;
    cout << "-> ";
    cin >> choice;

    switch (choice) {
        case 1: RunSync(); break;
        case 2: RunUnsafe(); break;
        case 3: RunSafe(); break;
    }

    return 0;
}