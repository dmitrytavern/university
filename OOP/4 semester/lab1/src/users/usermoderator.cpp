#include "users/usermoderator.h"
#include "users/actions.h"
#include "stores/userstore.h"
#include "ui.h"

UserModerator::UserModerator(std::string username) : Account(username)
{
  this->role = "moderator";
}

void UserModerator::printActions(char *action)
{
  UI::printMenu({"[1] Change my name",
                 "[2] Print my name",
                 "[3] Print my role",
                 "[4] Print other users",
                 "[5] Change user name",
                 "[e] Exit"});
  std::cout << "Your choice: ";
  std::cin >> *action;
}

void UserModerator::activateAction(char *action)
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
  case '4':
    UserStore::printUsers();
    UI::pressEnter();
    break;
  case '5':
    UserStore::printUsers();
    std::cout << "\n";
    Actions::changeUserName(this);
    UI::pressEnter();
    break;
  }
}
