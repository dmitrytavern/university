#pragma once
#include <iostream>
#include "../users/user.h"
#include "../users/useradmin.h"
#include "../users/usermoderator.h"

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
