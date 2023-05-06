#include <QDebug>
#include <QFile>
#include <QTextStream>
#include <cstdio>
#include <qdebug.h>

// Завдання: Напишіть програму, яка використовує <QTextStream> для зчитування
// даних з текстового файлу. Програма повинна зчитувати кожен рядок з файлу та
// виводити його на екран консолі.
void run_task_1();

// Напишіть програму, яка використовує <QTextStream> для запису даних у
// текстовий файл. Програма повинна запитувати користувача про введення рядка
// тексту, та записувати цей рядок у файл.
void run_task_2();

// Напишіть програму, яка використовує <QTextStream> для зчитування даних з
// консолі та виводу їх на екран. Програма повинна чекати введення користувача
// та виводити введений рядок на екран.
void run_task_3();

// Напишіть програму, яка використовує <QTextStream> для зчитування чисел з
// текстового файлу та знаходження їх середнього арифметичного. Програма повинна
// зчитувати кожне число з файлу та додавати його до змінної, яка зберігає
// загальну суму чисел. Після цього програма повинна обчислити середнє
// арифметичне за допомогою формули sum / n, де sum - загальна сума чисел, а n -
// кількість чисел.
void run_task_4();

// Напишіть програму, яка використовує <QTextStream> для зчитування даних з
// текстового файлу та запису даних у інший текстовий файл. Програма повинна
// зчитувати кожен рядок з файлу та записувати його до нового файлу, при цьому
// замінюючи усі входження певного слова на інше слово. Слова для заміни
// програма повинна запитувати у користувача
void run_task_5();

int main()
{
  qInfo() << "Enter task number: (1-5): ";

  QTextStream s(stdin);
  QString value = s.readLine();

  if (value == "1")
  {
    run_task_1();
    return 0;
  }

  if (value == "2")
  {
    run_task_2();
    return 0;
  }

  if (value == "3")
  {
    run_task_3();
    return 0;
  }

  if (value == "4")
  {
    run_task_4();
    return 0;
  }

  if (value == "5")
  {
    run_task_5();
    return 0;
  }

  qDebug() << value;
  return 1;
}

void run_task_1()
{
  QFile file("./data/task1.txt");

  if (file.open(QIODevice::ReadOnly | QIODevice::Text))
  {
    QTextStream in(&file);
    QString line;

    while (!in.atEnd())
    {
      qDebug() << in.readLine();
    }

    return;
  }

  qDebug("[task1]: cannot read the file.");
}

void run_task_2()
{

  QFile file("./data/task2.txt");
  if (file.open(QIODevice::WriteOnly | QIODevice::Text))
  {
    qInfo() << "Enter the file row:";

    QTextStream s(stdin);
    QString value = s.readLine();

    QTextStream out(&file);
    out << value << "\n";

    file.close();

    return;
  }

  qDebug("[task2]: cannot read the file.");
}

void run_task_3()
{
  qInfo() << "Enter string:";
  QTextStream s(stdin);
  QString value = s.readLine();
  qInfo() << "Your string: " << value;
}

void run_task_4()
{
  QFile file("./data/task4.txt");

  if (file.open(QIODevice::ReadOnly | QIODevice::Text))
  {
    QTextStream in(&file);
    QString line;

    double sum = 0;
    int n = 0;

    while (!in.atEnd())
    {
      sum += in.readLine().toDouble();
      n++;
    }

    qInfo() << "Your average: " << sum / n;

    file.close();

    return;
  }

  qDebug("[task4]: cannot read the file.");
}

void run_task_5()
{
  QFile file_source("./data/task5_source.txt");
  QFile file_dist("./data/task5_dist.txt");

  if (file_source.open(QIODevice::ReadOnly | QIODevice::Text))
  {
    if (file_dist.open(QIODevice::WriteOnly | QIODevice::Text))
    {
      QTextStream s(stdin);
      QTextStream out(&file_dist);

      qInfo() << "Enter the source word:";
      QString source_word = s.readLine();

      qInfo() << "Enter the dist word:";
      QString dist_word = s.readLine();

      QTextStream in(&file_source);
      QString line;

      while (!in.atEnd())
      {
        line = in.readLine();
        line.replace(source_word, dist_word);
        out << line << "\n";
      }

      qInfo() << "File success copied!";

      file_source.close();
      file_dist.close();

      return;
    }
  }

  qDebug("[task5]: cannot read or wirte to files.");
}