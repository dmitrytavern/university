#pragma once
#include <iostream>
#include "./User.h"

class UserAdmin : public User
{
public:
  UserAdmin(std::string username);

protected:
  void printActions(char *input) override;
  void activateAction(char *input) override;

private:
  void actionSetUserName();
  void actionDeleteUser();
};
