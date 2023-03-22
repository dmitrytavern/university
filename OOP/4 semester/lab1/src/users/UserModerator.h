#pragma once
#include <iostream>
#include "./User.h"

class UserModerator : public User
{
public:
  UserModerator(std::string username);

protected:
  void printActions(char *input) override;
  void activateAction(char *input) override;

private:
  void actionSetUserName();
};
