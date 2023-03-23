#pragma once
#include <iostream>
#include <vector>

class UI
{
public:
  static void clear();
  static void pressEnter();
  static void printMenu(std::vector<std::string>);
  static void printTitle(std::string);
};