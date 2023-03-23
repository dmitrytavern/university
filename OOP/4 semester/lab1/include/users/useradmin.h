#pragma once
#include <iostream>
#include "./account.h"

class UserAdmin : public Account
{
public:
  UserAdmin(std::string username);

protected:
  void printActions(char *input) override;
  void activateAction(char *input) override;
};
