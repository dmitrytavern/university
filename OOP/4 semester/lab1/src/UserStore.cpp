#include "./UserStore.h"

std::vector<User *> UserStore::users = {};

std::vector<User *> UserStore::getUsers()
{
  return UserStore::users;
}

void UserStore::addUser(User *user)
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
  std::vector<User *> users = UserStore::getUsers();

  std::cout << "Users:" << std::endl;
  std::cout << "index - name - role" << std::endl;

  for (int i = 0; i < users.size(); i++)
  {
    std::cout << i << " - "
              << users[i]->getName() << " - "
              << users[i]->getRole()
              << std::endl;
  }
}