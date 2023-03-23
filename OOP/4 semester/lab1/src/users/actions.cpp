#include <string>
#include "ui.h"
#include "users/actions.h"
#include "stores/userstore.h"

void Actions::printName(Account *user)
{
  UI::printTitle("Name output");
  std::cout << "\n";
  std::cout << "Your name is: " << user->getName() << std::endl;
}

void Actions::printRole(Account *user)
{
  UI::printTitle("Role output");
  std::cout << "\n";
  std::cout << "Your name is: " << user->getRole() << std::endl;
}

void Actions::changeName(Account *user)
{
  UI::printTitle("Name changing");
  std::cout << "\n";

  std::string newName;
  std::cout << "Enter new name: ";
  std::cin >> newName;
  user->setName(newName);
  std::cout << "Name successful changed!" << std::endl;
}

void Actions::changeUserName(Account *user)
{
  UI::printTitle("Name changing");
  std::cout << "\n";

  int userIndex;
  int currectUserIndex;
  std::string userName;
  std::vector<Account *> users = UserStore::getUsers();

  for (int i = 0; i < users.size(); i++)
  {
    if (users[i] == user)
    {
      currectUserIndex = i;
    }
  }

  do
  {
    std::cout << "Enter user index: ";
    std::cin >> userIndex;
  } while (userIndex < 0 || userIndex > users.size() || userIndex == currectUserIndex);

  std::cout << "Enter new name for user: ";
  std::cin >> userName;
  users[userIndex]->setName(userName);
  std::cout << "Name successful changed!" << std::endl;
}

void Actions::deleteUser(Account *user)
{
  UI::printTitle("User deleting");
  std::cout << "\n";

  int userIndex;
  int currectUserIndex;
  std::string userName;
  std::vector<Account *> users = UserStore::getUsers();

  for (int i = 0; i < users.size(); i++)
  {
    if (users[i] == user)
    {
      currectUserIndex = i;
    }
  }

  do
  {
    std::cout << "Enter user index: ";
    std::cin >> userIndex;
  } while (userIndex < 0 || userIndex > users.size() || userIndex == currectUserIndex);

  UserStore::removeUser(userIndex);

  std::cout << "User successful deleted!" << std::endl;
}
