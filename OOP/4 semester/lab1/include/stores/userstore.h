#pragma once
#include <vector>
#include <iostream>
#include "../users/user.h"

class UserStore
{
public:
  static std::vector<Account *> getUsers();
  static void addUser(Account *user);
  static void removeUser(int index);
  static void printUsers();

private:
  static std::vector<Account *> users;
};
