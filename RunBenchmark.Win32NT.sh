#!/bin/bash
dotnet run --project=CSharpBasic/CSharpBasic.csproj --configuration=Release
cmake -B build/Win32NT .
cmake --build build/Win32NT --config Release -j `nproc`
./build/Win32NT/CxxBasic/Release/CxxBasic.exe
