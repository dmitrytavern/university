#include "ui.h"
#include "users/user.h"
#include "users/actions.h"

User::User(std::string username) : Account(username)
{
  this->role = "user";
}

void User::printActions(char *action)
{
  UI::printMenu({"[1] Change my name",
                 "[2] Print my name",
                 "[3] Print my role",
                 "[e] Exit"});
  std::cout << "Your choice: ";
  std::cin >> *action;
}

void User::activateAction(char *action)
{
  switch (*action)
  {
  case '1':
    Actions::changeName(this);
    UI::pressEnter();
    break;
  case '2':
    Actions::printName(this);
    UI::pressEnter();
    break;
  case '3':
    Actions::printRole(this);
    UI::pressEnter();
    break;
  }
}
