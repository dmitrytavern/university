#pragma once
#include <iostream>
#include "./users/User.h"
#include "./users/UserAdmin.h"
#include "./users/UserModerator.h"

struct UserData
{
  std::string username;
  std::string password;
  std::string name;
  std::string role;
};

class UserFactory
{
public:
  static void createUser(UserData data);
};
