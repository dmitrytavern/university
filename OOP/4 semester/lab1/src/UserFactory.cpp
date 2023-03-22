#include <iostream>
#include "./users/User.h"
#include "./users/UserAdmin.h"
#include "./users/UserModerator.h"
#include "./UserFactory.h"
#include "./UserStore.h"
#include "./Authorization.h"

void UserFactory::createUser(UserData data)
{
  User *user;

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
