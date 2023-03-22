#pragma once
#include <vector>
#include "./users/User.h"

struct AuthRules
{
  User *user;
  std::string username;
  std::string password;
};

class Authorization
{
public:
  static User *get();
  static int auth(std::string username, std::string password);
  static void addRule(AuthRules rule);

private:
  static User *user;
  static std::vector<AuthRules> rules;
};
