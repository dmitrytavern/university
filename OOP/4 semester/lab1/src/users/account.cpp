#include "ui.h"
#include "users/account.h"

Account::Account(std::string username)
{
  this->role = "user";
  this->username = username;
}

std::string Account::getName()
{
  return this->username;
}

std::string Account::getRole()
{
  return this->role;
}

void Account::setName(std::string username)
{
  this->username = username;
}

void Account::init()
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

void Account::printActions(char *action)
{
  std::cout << "Actions not found." << std::endl;
  std::cin >> *action;
}

void Account::activateAction(char *action)
{
  std::cout << "Actions not activated." << std::endl;
}
