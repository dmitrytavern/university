#include <iomanip>
#include "stores/userstore.h"

std::vector<Account *> UserStore::users = {};

std::vector<Account *> UserStore::getUsers()
{
  return UserStore::users;
}

void UserStore::addUser(Account *user)
{
  UserStore::users.push_back(user);
}

void UserStore::removeUser(int index)
{
  if (index >= 0 || index <= UserStore::users.size())
  {
    UserStore::users.erase(users.begin() + index);
  }
}

void UserStore::printUsers()
{
  std::vector<Account *> users = UserStore::getUsers();

  std::cout << std::setfill('-') << std::setw(67) << "-" << std::endl;
  std::cout << std::setfill(' ');

  std::cout << "| " << std::setw(33) << "Users table" << std::setw(32)
            << "|" << std::endl;

  std::cout << std::setfill('-') << std::setw(67) << "-" << std::endl;
  std::cout << std::setfill(' ');

  std::cout << "| " << std::setw(10) << std::left << "ID"
            << "| " << std::setw(20) << std::left << "Name"
            << "| " << std::setw(30) << std::left << "Role"
            << "|" << std::endl;

  std::cout << std::setfill('-') << std::setw(67) << "-" << std::endl;
  std::cout << std::setfill(' ');

  for (int i = 0; i < users.size(); i++)
  {
    std::cout << "| " << std::setw(10) << std::left << i
              << "| " << std::setw(20) << std::left << users[i]->getName()
              << "| " << std::setw(30) << std::left << users[i]->getRole()
              << "|" << std::endl;
  }

  std::cout << std::setfill('-') << std::setw(67) << "-" << std::endl;
  std::cout << std::setfill(' ');
}