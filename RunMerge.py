#!/usr/bin/env python
import csv

def merge_csv(testcase):
    cs_unix = open("csharp.Unix.Release.bench." + testcase + ".csv", "r")
    cs_win32 = open("csharp.Win32NT.Release.bench." + testcase + ".csv", "r")
    cx_unix = open("cxx.Unix.Release.bench." + testcase + ".csv", "r")
    cx_win32 = open("cxx.Win32NT.Release.bench." + testcase + ".csv", "r")
    
    # Skip headlines
    cs_unix.readline();
    cs_win32.readline();
    cx_unix.readline();
    cx_win32.readline();
    
    target = open("merged.bench." + testcase + ".csv", "w");
    target.write("Iteration,C# (Unix),C# (Win32),C++ (Unix),C++ (Win32)\n");
    
    while True:
        lines = []
        lines.append(cs_unix.readline().rstrip("\r\n"))
        lines.append(cs_win32.readline().rstrip("\r\n"))
        lines.append(cx_unix.readline().rstrip("\r\n"))
        lines.append(cx_win32.readline().rstrip("\r\n"))
        
        iter = -1
        
        if iter == -1 and lines[0] != "":
            iter = int(lines[0].split(",")[0])
        elif iter == -1 and lines[1] != "":
            iter = int(lines[1].split(",")[0])
        elif iter == -1 and lines[2] != "":
            iter = int(lines[2].split(",")[0])
        elif iter == -1 and lines[3] != "":
            iter = int(lines[3].split(",")[0])
        
        if iter == -1:
            break
        
        tline = str(iter) + ","
        
        if lines[0] == "":
            tline += ","
        else:
            tline += lines[0].split(",")[1]
        tline += ","
        
        if lines[1] == "":
            tline += ","
        else:
            tline += lines[1].split(",")[1]
        tline += ","
        
        if lines[2] == "":
            tline += ","
        else:
            tline += lines[2].split(",")[1]
        tline += ","
        
        if lines[3] == "":
            tline += ","
        else:
            tline += lines[3].split(",")[1]
        
        tline += "\n"
        target.write(tline)
    
    target.close()
    
    cs_unix.close();
    cs_win32.close();
    cx_unix.close();
    cx_win32.close();

merge_csv("FibonacciArray")
merge_csv("FibonacciRecursive")
merge_csv("FourierTransform")
merge_csv("PowCosine")
merge_csv("QuakeInverseSqrt")
merge_csv("SquareRoot")
