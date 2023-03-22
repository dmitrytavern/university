cmake_minimum_required(VERSION 3.16)
project(lab1 VERSION 1.0.0 LANGUAGES CXX)

file(MAKE_DIRECTORY ${PROJECT_SOURCE_DIR}/bin/)
file(MAKE_DIRECTORY ${PROJECT_SOURCE_DIR}/build/)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/build)
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/build)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${PROJECT_SOURCE_DIR}/bin)
set(EXECUTABLE_OUTPUT_PATH ${PROJECT_SOURCE_DIR}/bin/)

find_package(Qt6 REQUIRED COMPONENTS Widgets)
qt_standard_project_setup()

include_directories(${PROJECT_BINARY_DIR})
include_directories(${PROJECT_SOURCE_DIR})

add_executable(lab1
  main.cpp
)

target_link_libraries(lab1
  PRIVATE Qt6::Widgets
)

set_target_properties(lab1 PROPERTIES
    WIN32_EXECUTABLE ON
    MACOSX_BUNDLE ON
)
