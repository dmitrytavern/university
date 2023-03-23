#include "authorization.h"
#include "factories/userfactory.h"

int main()
{
  int login = 0;

  UserFactory::createUser({.username = "dmitry",
                           .password = "1",
                           .name = "Dmitry",
                           .role = "admin"});

  UserFactory::createUser({.username = "alex",
                           .password = "1",
                           .name = "Alex Joy",
                           .role = "moderator"});

  UserFactory::createUser({.username = "ura",
                           .password = "1",
                           .name = "Ura",
                           .role = "user"});

  do
  {
    std::string username;
    std::cout << "Enter login: ";
    std::cin >> username;

    std::string password;
    std::cout << "Enter password: ";
    std::cin >> password;

    login = Authorization::auth(username, password);

    if (login == 0)
    {
      std::cout << "Login or password is invalid." << std::endl;
    }
  } while (login == 0);

  Account *user = Authorization::get();

  user->init();
}
