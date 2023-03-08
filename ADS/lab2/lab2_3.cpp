// Lab #2
// Pointer.
//
// Task: Create a program that organizes a given data structure.
//
// Description: You need to write a program that works with a specified
// data structure. The program should allow the user to input data into the
// structure, view the data in the structure, view the information of a specified
// field in the structure through a pointer, and provide information according to
// the task variant. To implement the third menu item, the program should prompt
// the user to enter the ordinal number of the structure record and use a pointer
// to navigate to the specified record. The program should then use the dereference
// operation to provide the user with the data of the specified record field.
// The program should also provide information based on the task variant, which
// is not specified in this prompt.
//

#include <iostream>
#include <string>

using namespace std;

const int TRAIN_LENGTH_MAX = 10;

struct Train
{
  int number;
  string station;
  string time;
};

void main_menu(char *input);
void input_train(Train *trains, int *trains_length);
void output_trains(Train *trains, int *trains_length);
void output_trains_by_index(Train *trains, int *trains_length);
void output_trains_by_station(Train *trains, int *trains_length);
void press_enter();

int main()
{
  int trains_length = 0;
  char main_menu_task;
  Train trains[TRAIN_LENGTH_MAX];
  Train *trains_pointer = trains;

  do
  {
    system("clear");
    main_menu(&main_menu_task);
    system("clear");

    switch (main_menu_task)
    {
    case '1':
      input_train(trains_pointer, &trains_length);
      break;
    case '2':
      output_trains(trains_pointer, &trains_length);
      break;
    case '3':
      output_trains_by_index(trains_pointer, &trains_length);
      break;
    case '4':
      output_trains_by_station(trains_pointer, &trains_length);
      break;
    }

    if (main_menu_task == 'e')
      break;
  } while (true);
}

void main_menu(char *input)
{
  cout << "1 - Add train" << endl;
  cout << "2 - Output all trains" << endl;
  cout << "3 - Output trains by index" << endl;
  cout << "4 - Output trains by station" << endl;
  cout << "e - Exit" << endl;
  cout << "Your answer: ";
  cin >> *input;
}

void input_train(Train *trains, int *trains_length)
{
  if (*trains_length >= TRAIN_LENGTH_MAX)
  {
    cout << "Alreay max trains count." << endl;
    press_enter();
    return;
  }

  cout << "Input train number: ";
  cin >> (trains + *trains_length)->number;
  cout << "Input train station: ";
  cin >> (trains + *trains_length)->station;
  cout << "Input train time: ";
  cin >> (trains + *trains_length)->time;
  (*trains_length)++;
}

void output_trains(Train *trains, int *trains_length)
{
  for (int index = 0; index < *trains_length; index++)
  {
    cout << "Train number: " << (trains + index)->number << endl;
    cout << "Train station: " << (trains + index)->station << endl;
    cout << "Train time: " << (trains + index)->time << endl;
    cout << endl;
  }

  cout << "Total trains: " << *trains_length << endl;

  press_enter();
}

void output_trains_by_index(Train *trains, int *trains_length)
{
  int train_index;

  cout << "Train index: ";
  cin >> train_index;
  cout << "\n";

  if (train_index < *trains_length)
    cout << "The train #" << (trains + train_index)->number << " leaves at " << (trains + train_index)->time << endl;
  else
    cout << "Train not found" << endl;

  press_enter();
}

void output_trains_by_station(Train *trains, int *trains_length)
{
  int trains_found = 0;
  string search_query;

  cout << "Search: ";
  cin >> search_query;
  cout << "\n";

  for (int index = 0; index < *trains_length; index++)
  {
    if (search_query == (trains + index)->station)
    {
      cout << "The train #" << (trains + index)->number << " leaves at " << (trains + index)->time << endl;
      trains_found++;
    }
  }

  if (trains_found)
    cout << "Total found: " << trains_found << endl;
  else
    cout << "Trains not found" << endl;

  press_enter();
}

void press_enter()
{
  cout << "Enter to continue..." << endl;
  cin.ignore(10, '\n');
  cin.get();
}
