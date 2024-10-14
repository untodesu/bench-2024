# On Unix-likes
## CSharpBasic
```
dotnet run --project=CSharpBasic/CSharpBasic.csproj --configuration=Release --arch=x64
```

## CxxBasic
```
cmake -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build -j $(nproc)
./build/CxxBasic/CxxBasic
```

# On Windows with Visual Studio
1. Open `Bench2024.sln` in VS2022
2. Set `CSharpBasic` as run project, select Release and click "Run without Debugger"
3. Set `CxxBasic` as run project, select Release and click "Run without Debugger"

# On Windows
## CSharpBasic
```
dotnet run --project=CSharpBasic\CSharpBasic.csproj --configuration=Release --arch=x64
```

## CxxBasic
```
cmake -B build
cmake --build build --config Release
build\CxxBasic\CxxBasic.exe
```
