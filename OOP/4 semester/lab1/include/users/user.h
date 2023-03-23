#pragma once
#include <iostream>
#include "./account.h"

class User : public Account
{
public:
  User(std::string username);

protected:
  void printActions(char *input) override;
  void activateAction(char *input) override;
};
