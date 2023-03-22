#include "./UI.h"

void UI::clear()
{
#ifdef __linux__
  system("clear");
#else
  system("cls");
#endif
}

void UI::pressEnter()
{
  std::cout << "Enter to continue..." << std::endl;
  std::cin.ignore(10, '\n');
  std::cin.get();
}
