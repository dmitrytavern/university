#include "./User.h"
#include "../UI.h"

User::User(std::string username)
{
  this->role = "user";
  this->username = username;
}

std::string User::getName()
{
  return this->username;
}

std::string User::getRole()
{
  return this->role;
}

void User::setName(std::string username)
{
  this->username = username;
}

void User::openActionsMenu()
{
  char action;
  do
  {
    UI::clear();
    this->printActions(&action);
    UI::clear();
    this->activateAction(&action);
    if (action == 'e')
      break;
  } while (true);
}

void User::printActions(char *action)
{
  std::cout << "Actions menu:" << std::endl;
  std::cout << "1 - set my name" << std::endl;
  std::cout << "2 - print my name" << std::endl;
  std::cout << "3 - print my role" << std::endl;
  std::cout << "e - exit" << std::endl;
  std::cin >> *action;
}

void User::activateAction(char *action)
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
  }
}

void User::actionPrintName()
{
  std::cout << "Your name is: " << this->username << std::endl;
}

void User::actionPrintRole()
{
  std::cout << "Your role is: " << this->role << std::endl;
}

void User::actionChangeName()
{
  std::string newName;
  std::cout << "Enter new name: ";
  std::cin >> newName;
  this->setName(newName);
  std::cout << "Name successful changed!" << std::endl;
}
