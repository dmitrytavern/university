#include <iostream>
#include <thread>
#include <chrono>
#include <cmath>
#include <vector>

using namespace std;

// Задача 1: Розрахунок палива. Результат записується в resRef
void CalcFuel(double mass, double dist, double& resRef) {
    cout << "[ID:" << this_thread::get_id() << "] Розрахунок палива..." << endl;
    this_thread::sleep_for(1s);
    // Імітація формули
    resRef = (mass * dist) / 1000.0 * 1.5;
    cout << "[ID:" << this_thread::get_id() << "] Паливо розраховано." << endl;
}

// Задача 2: Час прибуття
void CalcEta(double dist, double speed, double& resRef) {
    cout << "[ID:" << this_thread::get_id() << "] Розрахунок часу..." << endl;
    this_thread::sleep_for(1500ms);
    if (speed > 0) resRef = dist / speed;
    else resRef = -1.0;
    cout << "[ID:" << this_thread::get_id() << "] Час розраховано." << endl;
}

// Задача 3: Цілісність щитів
void CalcShields(int hits, double& resRef) {
    cout << "[ID:" << this_thread::get_id() << "] Дiагностика щитiв..." << endl;
    this_thread::sleep_for(2s);
    double integrity = 100.0 - (hits * 12.5);
    resRef = (integrity < 0) ? 0.0 : integrity;
    cout << "[ID:" << this_thread::get_id() << "] Щити перевiрено." << endl;
}

// 3.1 Синхронний режим
void RunSync() {
    cout << "--- Sync Mode ---" << endl;
    double fuel = 0, eta = 0, shield = 0;
    auto start = chrono::high_resolution_clock::now();

    CalcFuel(5000, 1000, fuel);
    CalcEta(1000, 50, eta);
    CalcShields(3, shield);

    auto end = chrono::high_resolution_clock::now();
    chrono::duration<double> dur = end - start;

    cout << "Результати:\nПаливо: " << fuel << "\nЧас: " << eta << "\nЩити: " << shield << "%" << endl;
    cout << "Час виконання: " << dur.count() << "s" << endl;
}

// 3.2 Detach режим (небезпечний для локальних посилань)
void RunDetach() {
    cout << "--- Detach Mode ---" << endl;
    // Змінні мають жити довше за потоки, інакше буде segfault
    static double fuel = 0, eta = 0, shield = 0; 
    
    auto start = chrono::high_resolution_clock::now();

    // Використовуємо std::ref для передачі посилання
    thread t1(CalcFuel, 5000, 1000, ref(fuel));
    thread t2(CalcEta, 1000, 50, ref(eta));
    thread t3(CalcShields, 3, ref(shield));

    t1.detach();
    t2.detach();
    t3.detach();

    // Чекаємо трохи, щоб потоки встигли щось записати (імітація роботи main)
    this_thread::sleep_for(2500ms);

    auto end = chrono::high_resolution_clock::now();
    chrono::duration<double> dur = end - start;

    cout << "Результати (можуть бути неповнi, якщо sleep замалий):\nПаливо: " << fuel 
         << "\nЧас: " << eta << "\nЩити: " << shield << "%" << endl;
    cout << "Час (зi sleep): " << dur.count() << "s" << endl;
}

// 3.3 Join режим (коректний)
void RunJoin() {
    cout << "--- Join Mode ---" << endl;
    double fuel = 0, eta = 0, shield = 0;
    auto start = chrono::high_resolution_clock::now();

    thread t1(CalcFuel, 5000, 1000, ref(fuel));
    thread t2(CalcEta, 1000, 50, ref(eta));
    thread t3(CalcShields, 3, ref(shield));

    t1.join();
    t2.join();
    t3.join();

    auto end = chrono::high_resolution_clock::now();
    chrono::duration<double> dur = end - start;

    cout << "Результати:\nПаливо: " << fuel << "\nЧас: " << eta << "\nЩити: " << shield << "%" << endl;
    cout << "Час виконання: " << dur.count() << "s" << endl;
}

int main() {
    int mode;
    cout << "Лабораторна робота No3. Оберiть режим:" << endl;
    cout << "1. Синхронний" << endl;
    cout << "2. Асинхронний (detach)" << endl;
    cout << "3. Асинхронний (join)" << endl;
    cout << "-> ";
    cin >> mode;

    switch(mode) {
        case 1: RunSync(); break;
        case 2: RunDetach(); break;
        case 3: RunJoin(); break;
        default: cout << "Помилка вибору." << endl;
    }

    return 0;
}