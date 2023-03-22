#pragma once
#include <vector>
#include <iostream>
#include "./users/User.h"

class UserStore
{
public:
  static std::vector<User *> getUsers();
  static void addUser(User *user);
  static void removeUser(int index);
  static void printUsers();

private:
  static std::vector<User *> users;
};
