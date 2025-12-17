#include <iostream>
#include <thread>
#include <chrono>
#include <vector>

using namespace std;

void CheckLifeSupport() {
    auto id = this_thread::get_id();
    cout << "[Потік " << id << "] Початок перевірки життєзабезпечення..." << endl;
    
    for (int i = 0; i < 4; ++i) {
        this_thread::sleep_for(500ms);
        cout << "[Потік " << id << "] Життєзабезпечення: тест " << i + 1 << "/4" << endl;
    }
    
    cout << "[Потік " << id << "] Життєзабезпечення: НОРМА." << endl;
}

void CalculateTrajectory() {
    auto id = this_thread::get_id();
    cout << "[Потік " << id << "] Початок розрахунку траєкторії..." << endl;
    
    for (int i = 0; i < 6; ++i) {
        this_thread::sleep_for(500ms);
    }
    
    cout << "[Потік " << id << "] Траєкторія обчислена." << endl;
}

void ScanHull() {
    auto id = this_thread::get_id();
    cout << "[Потік " << id << "] Сканування обшивки..." << endl;
    
    this_thread::sleep_for(1500ms);
    
    cout << "[Потік " << id << "] Обшивка: пошкоджень не виявлено." << endl;
}

void RunSync() {
    cout << "=== Запуск у синхронному режимi ===" << endl;
    auto start = chrono::high_resolution_clock::now();

    CheckLifeSupport();
    CalculateTrajectory();
    ScanHull();

    auto end = chrono::high_resolution_clock::now();
    chrono::duration<double> duration = end - start;
    cout << "=== Завершено. Час виконання: " << duration.count() << " с ===" << endl;
}

void RunAsyncDetach() {
    cout << "=== Запуск у режимi detach() ===" << endl;
    auto start = chrono::high_resolution_clock::now();

    thread t1(CheckLifeSupport);
    thread t2(CalculateTrajectory);
    thread t3(ScanHull);

    // Потоки виконуються незалежно, зв'язок втрачається
    t1.detach();
    t2.detach();
    t3.detach();

    // Головний потік не чекає завершення, тому час буде майже 0.
    // Додамо sleep, щоб встигнути побачити хоч щось у консолі перед виходом з функції (імітація роботи main)
    this_thread::sleep_for(1s); 

    auto end = chrono::high_resolution_clock::now();
    chrono::duration<double> duration = end - start;
    cout << "=== Main завершив роботу (але потоки ще можуть працювати). Час main: " << duration.count() << " с ===" << endl;

    this_thread::sleep_for(3s);
}

void RunAsyncJoin() {
    cout << "=== Запуск у режимi join() ===" << endl;
    auto start = chrono::high_resolution_clock::now();

    thread t1(CheckLifeSupport);
    thread t2(CalculateTrajectory);
    thread t3(ScanHull);

    // Головний потік чекає завершення всіх запущених потоків
    if(t1.joinable()) t1.join();
    if(t2.joinable()) t2.join();
    if(t3.joinable()) t3.join();

    auto end = chrono::high_resolution_clock::now();
    chrono::duration<double> duration = end - start;
    cout << "=== Всi потоки завершено коректно. Час виконання: " << duration.count() << " с ===" << endl;
}

int main() {
    int choice;
    cout << "Лабораторна робота No1. Оберiть режим:" << endl;
    cout << "1. Синхронний (однопотоковий)" << endl;
    cout << "2. Асинхронний (detach - без очiкування)" << endl;
    cout << "3. Асинхронний (join - з очiкуванням)" << endl;
    cout << "Ваш вибiр: ";
    cin >> choice;

    switch (choice) {
        case 1: RunSync(); break;
        case 2: RunAsyncDetach(); break;
        case 3: RunAsyncJoin(); break;
        default: cout << "Невiрний вибiр." << endl;
    }

    return 0;
}