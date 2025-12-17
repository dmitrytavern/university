#include <iostream>
#include <thread>
#include <chrono>
#include <string>

using namespace std;

// Задача 1: Заправка двигуна (int, double)
void RefuelEngine(int engineId, double fuelAmount) {
    auto id = this_thread::get_id();
    cout << "[Потiк " << id << "] Розпочато заправку двигуна #" << engineId 
         << " об'ємом " << fuelAmount << " тон." << endl;
    
    int duration = (int)fuelAmount * 10;
    if (duration > 2000) duration = 2000;
    
    this_thread::sleep_for(chrono::milliseconds(duration));
    
    cout << "[Потiк " << id << "] Двигун #" << engineId << " заправлено." << endl;
}

// Задача 2: Розрахунок курсу (string, int)
void PlotCourse(string destination, int warpSpeed) {
    auto id = this_thread::get_id();
    cout << "[Потiк " << id << "] Розрахунок курсу на " << destination 
         << " при варп-швидкостi " << warpSpeed << "." << endl;
    
    this_thread::sleep_for(1500ms);
    
    cout << "[Потiк " << id << "] Курс на " << destination << " прокладено." << endl;
}

// Задача 3: Аналіз спектру (char)
void AnalyzeStarSpectrum(char starClass) {
    auto id = this_thread::get_id();
    cout << "[Потiк " << id << "] Аналiз спектру зiрки класу '" << starClass << "'..." << endl;
    
    this_thread::sleep_for(1s);
    
    cout << "[Потiк " << id << "] Спектральний аналiз класу '" << starClass << "' завершено." << endl;
}

void RunSync() {
    cout << "=== Синхронний режим ===" << endl;
    auto start = chrono::high_resolution_clock::now();

    RefuelEngine(1, 150.5);
    PlotCourse("Марс", 8);
    AnalyzeStarSpectrum('G');

    auto end = chrono::high_resolution_clock::now();
    chrono::duration<double> duration = end - start;
    cout << "Час виконання: " << duration.count() << " с" << endl;
}

void RunAsyncDetach() {
    cout << "=== Режим Detach (без зв'язку) ===" << endl;
    auto start = chrono::high_resolution_clock::now();

    thread t1(RefuelEngine, 1, 150.5);
    thread t2(PlotCourse, "Марс", 8);
    thread t3(AnalyzeStarSpectrum, 'G');

    t1.detach();
    t2.detach();
    t3.detach();

    // Емуляція роботи головного потоку, інакше програма завершиться миттєво
    cout << "Main: потоки запущені, я не чекаю їх завершення." << endl;
    this_thread::sleep_for(200ms); 

    auto end = chrono::high_resolution_clock::now();
    chrono::duration<double> duration = end - start;
    cout << "Час роботи Main: " << duration.count() << " с (реальні потоки можуть ще працювати)" << endl;
    
    this_thread::sleep_for(3s);
}

void RunAsyncJoin() {
    cout << "=== Режим Join (з очiкуванням) ===" << endl;
    auto start = chrono::high_resolution_clock::now();

    string dest = "Марс";
    thread t1(RefuelEngine, 1, 150.5);
    thread t2(PlotCourse, dest, 8);
    thread t3(AnalyzeStarSpectrum, 'G');

    if(t1.joinable()) t1.join();
    if(t2.joinable()) t2.join();
    if(t3.joinable()) t3.join();

    auto end = chrono::high_resolution_clock::now();
    chrono::duration<double> duration = end - start;
    cout << "Час виконання: " << duration.count() << " с" << endl;
}

int main() {
    int choice;
    cout << "Лабораторна робота No2. Оберiть режим:" << endl;
    cout << "1. Синхронний" << endl;
    cout << "2. Асинхронний (detach)" << endl;
    cout << "3. Асинхронний (join)" << endl;
    cout << "-> ";
    cin >> choice;

    switch (choice) {
        case 1: RunSync(); break;
        case 2: RunAsyncDetach(); break;
        case 3: RunAsyncJoin(); break;
        default: cout << "Помилка вибору." << endl;
    }

    return 0;
}