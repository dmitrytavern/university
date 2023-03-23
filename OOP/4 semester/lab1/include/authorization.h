#pragma once
#include <vector>
#include "./users/user.h"

struct AuthRules
{
  Account *user;
  std::string username;
  std::string password;
};

class Authorization
{
public:
  static Account *get();
  static int auth(std::string username, std::string password);
  static void addRule(AuthRules rule);

private:
  static Account *user;
  static std::vector<AuthRules> rules;
};
