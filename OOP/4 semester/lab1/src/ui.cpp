#include <iomanip>
#include "ui.h"

void UI::clear()
{
#ifdef __linux__
  system("clear");
#else
  system("cls");
#endif
}

void UI::printTitle(std::string title)
{
  std::cout << std::setfill('-') << std::setw(67) << "-" << std::endl;
  std::cout << std::setfill(' ');

  std::cout << "| " << std::setw(64) << std::left << title
            << "|" << std::endl;

  std::cout << std::setfill('-') << std::setw(67) << "-" << std::endl;
  std::cout << std::setfill(' ');
}

void UI::printMenu(std::vector<std::string> items)
{
  std::cout << std::setfill('-') << std::setw(67) << "-" << std::endl;
  std::cout << std::setfill(' ');

  std::cout << "| " << std::setw(64) << std::left << "Main menu"
            << "|" << std::endl;

  std::cout << std::setfill('-') << std::setw(67) << "-" << std::endl;
  std::cout << std::setfill(' ');

  for (int i = 0; i < items.size(); i++)
  {
    std::cout << "| " << std::setw(64) << std::left << items[i]
              << "|" << std::endl;
  }

  std::cout << std::setfill('-') << std::setw(67) << "-" << std::endl;
  std::cout << std::setfill(' ');
}

void UI::pressEnter()
{
  std::cout << "Enter to continue..." << std::endl;
  std::cin.ignore(10, '\n');
  std::cin.get();
}
