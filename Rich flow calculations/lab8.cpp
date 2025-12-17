#include <iostream>
#include <thread>
#include <mutex>
#include <chrono>

using namespace std;

mutex mtxA; // Шлюз А
mutex mtxB; // Шлюз Б

// 1. Функція, що створює Deadlock (Різний порядок блокування)
void Engineer1_Unsafe() {
    // Захоплюємо А -> чекаємо -> хочемо Б
    mtxA.lock();
    cout << "[Iнженер 1] Захопив Шлюз А. Йду до Б..." << endl;
    
    this_thread::sleep_for(100ms); // Даємо час другому потоку захопити свій ресурс
    
    cout << "[Iнженер 1] Чекаю на Шлюз Б..." << endl;
    mtxB.lock(); // Тут буде вічне очікування
    
    cout << "[Iнженер 1] Захопив обидва шлюзи!" << endl;
    
    mtxB.unlock();
    mtxA.unlock();
}

void Engineer2_Unsafe() {
    // Захоплюємо Б -> чекаємо -> хочемо А
    mtxB.lock();
    cout << "[Iнженер 2] Захопив Шлюз Б. Йду до А..." << endl;
    
    this_thread::sleep_for(100ms);
    
    cout << "[Iнженер 2] Чекаю на Шлюз А..." << endl;
    mtxA.lock(); // Тут буде вічне очікування
    
    cout << "[Iнженер 2] Захопив обидва шлюзи!" << endl;
    
    mtxA.unlock();
    mtxB.unlock();
}

// 2. Безпечна функція (Однаковий порядок блокування)
// Обидва інженери завжди йдуть за схемою А -> Б
void Engineer_Safe(int id) {
    mtxA.lock();
    cout << "[Iнженер " << id << "] Захопив Шлюз А..." << endl;
    
    this_thread::sleep_for(50ms);
    
    mtxB.lock();
    cout << "[Iнженер " << id << "] Захопив Шлюз Б (успiх)!" << endl;
    
    // Робота
    this_thread::sleep_for(500ms);
    
    mtxB.unlock();
    mtxA.unlock();
    cout << "[Iнженер " << id << "] Звiльнив шлюзи." << endl;
}

void RunDeadlock() {
    cout << "=== Запуск Deadlock (Програма зависне!) ===" << endl;
    cout << "Для виходу натиснiть Ctrl+C в термiналi, якщо зависне." << endl;
    
    thread t1(Engineer1_Unsafe);
    thread t2(Engineer2_Unsafe);
    
    t1.join();
    t2.join();
}

void RunSafe() {
    cout << "=== Запуск Safe Mode (Iєрархiя ресурсiв) ===" << endl;
    
    thread t1(Engineer_Safe, 1);
    thread t2(Engineer_Safe, 2);
    
    t1.join();
    t2.join();
}

int main() {
    int choice;
    cout << "Лабораторна робота No8. Оберiть режим:" << endl;
    cout << "1. Deadlock (Зависання)" << endl;
    cout << "2. Safe Mode (Безпечно)" << endl;
    cout << "-> ";
    cin >> choice;

    switch (choice) {
        case 1: RunDeadlock(); break;
        case 2: RunSafe(); break;
    }

    return 0;
}