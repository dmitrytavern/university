#include <iostream>
#include "users/user.h"
#include "users/useradmin.h"
#include "users/usermoderator.h"
#include "factories/userfactory.h"
#include "stores/userstore.h"
#include "authorization.h"

void UserFactory::createUser(UserData data)
{
  Account *user;

  if (data.role == "admin")
  {
    user = new UserAdmin(data.name);
  }
  else if (data.role == "moderator")
  {
    user = new UserModerator(data.name);
  }
  else
  {
    user = new User(data.name);
  }

  UserStore::addUser(user);
  Authorization::addRule({.user = user,
                          .username = data.username,
                          .password = data.password});
}
