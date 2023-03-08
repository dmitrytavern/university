#include <iostream>
#include "Wall.h"

using namespace std;

void main_menu(char *input);
void press_enter();

int main()
{
  char main_menu_task;
  Wall wall;

  do
  {
    system("clear");
    main_menu(&main_menu_task);
    system("clear");

    switch (main_menu_task)
    {
    case '1':
      wall.Print();
      press_enter();
      break;
    case '2':
      float new_width;
      cout << "Input width: ";
      cin >> new_width;
      wall.SetWidth(new_width);
      break;
    case '3':
      float new_height;
      cout << "Input height: ";
      cin >> new_height;
      wall.SetHeight(new_height);
      break;
    case '4':
      cout << "Wall square: " << wall.CalcSquare() << endl;
      press_enter();
      break;
    case '5':
      string new_color;
      int choose = 0;

      cout << "For painting you need(l): " << wall.CalcPaint() << endl;

      cout << "Do you want paint? (1/0): ";
      cin >> choose;

      if (choose)
      {
        cout << "Input new color: ";
        cin >> new_color;
        wall.SetColor(new_color);
      }
    }

    if (main_menu_task == 'e')
      break;
  } while (true);
}

void main_menu(char *input)
{
  cout << "1 - Print wall" << endl;
  cout << "2 - Set width" << endl;
  cout << "3 - Set hegiht" << endl;
  cout << "4 - Calc square of wall" << endl;
  cout << "5 - Paint wall" << endl;
  cout << "e - Exit" << endl;
  cout << "Your answer: ";
  cin >> *input;
}

void press_enter()
{
  cout << "Enter to continue..." << endl;
  cin.ignore(10, '\n');
  cin.get();
}
