#pragma once
#include <iostream>

class User
{
public:
  User(std::string username);
  void setName(std::string username);
  void openActionsMenu();
  std::string getName();
  std::string getRole();

protected:
  std::string role;
  void actionPrintName();
  void actionPrintRole();
  void actionChangeName();
  virtual void printActions(char *input);
  virtual void activateAction(char *input);

private:
  std::string username;
};
