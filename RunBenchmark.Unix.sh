#!/bin/bash
dotnet run --project=CSharpBasic/CSharpBasic.csproj --configuration=Release
cmake -B build/Unix -DCMAKE_BUILD_TYPE=Release .
cmake --build build/Unix -j `nproc`
./build/Unix/CxxBasic/CxxBasic
