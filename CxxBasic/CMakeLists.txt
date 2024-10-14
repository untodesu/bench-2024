cmake_minimum_required(VERSION 3.10)
project(CxxBasic LANGUAGES CXX VERSION 1.0.0)
add_executable(CxxBasic
    "${CMAKE_CURRENT_LIST_DIR}/basebenchmark.cpp"
    "${CMAKE_CURRENT_LIST_DIR}/main.cpp")
target_compile_definitions(CxxBasic PRIVATE _CRT_SECURE_NO_WARNINGS)
target_compile_definitions(CxxBasic PRIVATE _USE_MATH_DEFINES)
target_include_directories(CxxBasic PRIVATE "${CMAKE_CURRENT_LIST_DIR}")
