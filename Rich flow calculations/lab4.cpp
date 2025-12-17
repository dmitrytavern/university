#include <iostream>
#include <vector>
#include <thread>
#include <chrono>
#include <random>
#include <algorithm>

using namespace std;

// Генерація даних
void GenerateData(vector<int>& data, int size) {
    mt19937 gen(time(0));
    uniform_int_distribution<> dist(1, 100);
    data.resize(size);
    for(int& x : data) x = dist(gen);
    cout << "Масив на " << size << " елементiв згенеровано." << endl;
}

// Задача 1: Кількість пар (важка операція)
long long CountPairs(const vector<int>& data) {
    auto id = this_thread::get_id();
    cout << "[ID:" << id << "] Пошук пар..." << endl;
    
    long long count = 0;
    size_t n = data.size();

    for (size_t i = 0; i < n; ++i) {
        for (size_t j = i + 1; j < n; ++j) {
            if (data[i] == data[j]) count++;
        }
    }
    
    cout << "[ID:" << id << "] Пари знайдено." << endl;
    return count;
}

// Задача 2: Найчастіший елемент (важка операція)
int FindFrequent(const vector<int>& data) {
    auto id = this_thread::get_id();
    cout << "[ID:" << id << "] Пошук частого..." << endl;

    int maxFreq = 0;
    int mostFrequent = data[0];
    size_t n = data.size();

    for (size_t i = 0; i < n; ++i) {
        int currentFreq = 0;
        for (size_t j = 0; j < n; ++j) {
            if (data[i] == data[j]) currentFreq++;
        }
        if (currentFreq > maxFreq) {
            maxFreq = currentFreq;
            mostFrequent = data[i];
        }
    }

    cout << "[ID:" << id << "] Частий знайдено." << endl;
    return mostFrequent;
}

// 3.1 Синхронний режим
void RunSync(const vector<int>& data) {
    cout << "--- Sync Mode ---" << endl;
    auto start = chrono::high_resolution_clock::now();

    long long pairs = CountPairs(data);
    int freq = FindFrequent(data);

    auto end = chrono::high_resolution_clock::now();
    cout << "Пари: " << pairs << ", Найчастiший: " << freq << endl;
    cout << "Час: " << chrono::duration<double>(end - start).count() << "s" << endl;
}

// 3.2 Асинхронний режим з лямбдами
void RunAsync(const vector<int>& data) {
    cout << "--- Async Mode (Lambda) ---" << endl;
    long long resPairs = 0;
    int resFreq = 0;

    auto start = chrono::high_resolution_clock::now();

    thread t1([&]() {
        resPairs = CountPairs(data);
    });

    thread t2([&]() {
        resFreq = FindFrequent(data);
    });

    t1.join();
    t2.join();

    auto end = chrono::high_resolution_clock::now();
    cout << "Пари: " << resPairs << ", Найчастiший: " << resFreq << endl;
    cout << "Час: " << chrono::duration<double>(end - start).count() << "s" << endl;
}

int main() {
    int choice;
    cout << "Лабораторна робота No4. Оберiть режим:" << endl;
    cout << "1. Синхронний" << endl;
    cout << "2. Асинхронний (join)" << endl;
    cout << "-> ";
    cin >> choice;

    int size;
    cout << "Введiть розмiр масиву (рекомендую 20000-50000): ";
    cin >> size;

    vector<int> data;
    GenerateData(data, size);

    switch (choice) {
        case 1: RunSync(data); break;
        case 2: RunAsync(data); break;
        default: cout << "Помилка вибору." << endl;
    }

    return 0;
}