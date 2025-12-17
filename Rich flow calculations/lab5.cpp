#include <iostream>
#include <thread>
#include <chrono>
#include <functional>

using namespace std;

class MarsRover {
public:
    // Задача 1: Метод без параметрів і повернення
    void UpdateFirmware() {
        auto id = this_thread::get_id();
        cout << "[ID:" << id << "] Оновлення прошивки..." << endl;
        this_thread::sleep_for(1500ms);
        cout << "[ID:" << id << "] Прошивку оновлено." << endl;
    }

    // Задача 2: Метод з параметрами, без повернення
    void TransmitTelemetry(int packets) {
        auto id = this_thread::get_id();
        cout << "[ID:" << id << "] Передача " << packets << " пакетiв телеметрiї..." << endl;
        for(int i=0; i<3; ++i) {
            this_thread::sleep_for(500ms);
        }
        cout << "[ID:" << id << "] Телеметрiю передано." << endl;
    }

    // Задача 3: Метод з поверненням результату
    int AnalyzeSoil(int depth) {
        auto id = this_thread::get_id();
        cout << "[ID:" << id << "] Бурiння на глибину " << depth << " см..." << endl;
        this_thread::sleep_for(2s);
        int density = depth * 5 + 20; // Умовна формула
        cout << "[ID:" << id << "] Аналiз завершено." << endl;
        return density;
    }
};

// 3.1 Синхронний режим
void RunSync() {
    cout << "--- Sync Mode ---" << endl;
    MarsRover rover;
    auto start = chrono::high_resolution_clock::now();

    rover.UpdateFirmware();
    rover.TransmitTelemetry(50);
    int soilRes = rover.AnalyzeSoil(10);

    auto end = chrono::high_resolution_clock::now();
    cout << "Результат аналiзу ґрунту: " << soilRes << endl;
    cout << "Час: " << chrono::duration<double>(end - start).count() << "s" << endl;
}

// 3.2 Асинхронний режим
void RunAsync() {
    cout << "--- Async Mode ---" << endl;
    MarsRover rover;
    int soilResult = 0;
    
    auto start = chrono::high_resolution_clock::now();

    thread t1(&MarsRover::UpdateFirmware, &rover);

    thread t2(&MarsRover::TransmitTelemetry, &rover, 50);

    thread t3([&]() {
        soilResult = rover.AnalyzeSoil(10);
    });

    t1.join();
    t2.join();
    t3.join();

    auto end = chrono::high_resolution_clock::now();
    cout << "Результат аналiзу ґрунту: " << soilResult << endl;
    cout << "Час: " << chrono::duration<double>(end - start).count() << "s" << endl;
}

int main() {
    int choice;
    cout << "Лабораторна робота No5. Оберiть режим:" << endl;
    cout << "1. Синхронний" << endl;
    cout << "2. Асинхронний (join)" << endl;
    cout << "-> ";
    cin >> choice;

    switch (choice) {
        case 1: RunSync(); break;
        case 2: RunAsync(); break;
        default: cout << "Помилка вибору." << endl;
    }

    return 0;
}