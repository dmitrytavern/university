#pragma once
#include "./user.h"

class Actions
{
public:
  static void printName(Account *user);
  static void printRole(Account *user);
  static void changeName(Account *user);
  static void changeUserName(Account *user);
  static void deleteUser(Account *user);
};
