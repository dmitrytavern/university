#pragma once
#include <iostream>

class Account
{
public:
  Account(std::string username);
  void init();
  void setName(std::string username);
  std::string getName();
  std::string getRole();

protected:
  std::string role;
  virtual void printActions(char *input);
  virtual void activateAction(char *input);

private:
  std::string username;
};
