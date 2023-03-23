#include "authorization.h"

Account *Authorization::user = nullptr;
std::vector<AuthRules> Authorization::rules = {};

Account *Authorization::get()
{
  return Authorization::user;
}

int Authorization::auth(std::string username, std::string password)
{
  for (int i = 0; i < Authorization::rules.size(); i++)
  {
    if (Authorization::rules[i].username == username)
    {
      if (Authorization::rules[i].password == password)
      {
        Authorization::user = Authorization::rules[i].user;
        return 1;
      }
    }
  }
  return 0;
}

void Authorization::addRule(AuthRules rule)
{
  Authorization::rules.push_back(rule);
}
