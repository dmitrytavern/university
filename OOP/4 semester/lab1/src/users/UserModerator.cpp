#include "./UserModerator.h"
#include "../UserStore.h"
#include "../UI.h"

UserModerator::UserModerator(std::string username) : User(username)
{
  this->role = "moderator";
}

void UserModerator::printActions(char *action)
{
  std::cout << "Actions menu:" << std::endl;
  std::cout << "  1 - set my name" << std::endl;
  std::cout << "  2 - print my name" << std::endl;
  std::cout << "  3 - print my role" << std::endl;
  std::cout << "Moderator menu:" << std::endl;
  std::cout << "  4 - print users" << std::endl;
  std::cout << "  5 - set user name" << std::endl;
  std::cout << "Other" << std::endl;
  std::cout << "  e - exit" << std::endl;
  std::cin >> *action;
}

void UserModerator::activateAction(char *action)
{
  switch (*action)
  {
  case '1':
    this->actionChangeName();
    UI::pressEnter();
    break;
  case '2':
    this->actionPrintName();
    UI::pressEnter();
    break;
  case '3':
    this->actionPrintRole();
    UI::pressEnter();
    break;
  case '4':
    UserStore::printUsers();
    UI::pressEnter();
    break;
  case '5':
    UserStore::printUsers();
    std::cout << "\n";
    this->actionSetUserName();
    UI::pressEnter();
    break;
  }
}

void UserModerator::actionSetUserName()
{
  int userIndex;
  std::string userName;
  std::vector<User *> users = UserStore::getUsers();

  std::cout << "Setting user name: " << std::endl;

  do
  {
    std::cout << "Enter user index: ";
    std::cin >> userIndex;
  } while (userIndex < 0 || userIndex > users.size());

  std::cout << "Enter new name for users: ";
  std::cin >> userName;
  users[userIndex]->setName(userName);
  std::cout << "Name successful changed!" << std::endl;
}
