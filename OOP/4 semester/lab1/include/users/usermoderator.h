#pragma once
#include <iostream>
#include "./account.h"

class UserModerator : public Account
{
public:
  UserModerator(std::string username);

protected:
  void printActions(char *input) override;
  void activateAction(char *input) override;
};
