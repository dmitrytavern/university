cmake_minimum_required (VERSION 3.15)
project(lab1 VERSION 1.0.0)

file(MAKE_DIRECTORY ${PROJECT_SOURCE_DIR}/bin/)
file(MAKE_DIRECTORY ${PROJECT_SOURCE_DIR}/build/)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/build)
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/build)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${PROJECT_SOURCE_DIR}/bin)
set(EXECUTABLE_OUTPUT_PATH ${PROJECT_SOURCE_DIR}/bin/)

include_directories(${PROJECT_SOURCE_DIR}/include)

add_executable(lab1
  src/ui.cpp
  src/main.cpp
  src/authorization.cpp
  src/stores/userstore.cpp
  src/factories/userfactory.cpp
  src/users/user.cpp
  src/users/useradmin.cpp
  src/users/usermoderator.cpp
  src/users/account.cpp
  src/users/actions.cpp
)
