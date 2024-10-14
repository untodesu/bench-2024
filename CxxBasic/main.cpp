#include "stdafx.h"
#include "basebenchmark.h"
#include "testcases/fibonacciarray.h"
#include "testcases/fibonaccirecursive.h"
#include "testcases/fouriertransform.h"
#include "testcases/powcosine.h"
#include "testcases/quareinversesqrt.h"
#include "testcases/squareroot.h"

#ifndef NDEBUG
#define CONFIGURATION "Debug"
#else
#define CONFIGURATION "Release"
#endif

#if defined(_WIN32)
#define PLATFORM "Win32NT"
#elif defined(__linux__)
#define PLATFORM "Linux"
#else
#define PLATFORM "Unknown"
#endif

int main(void) {
    std::vector<std::shared_ptr<BaseBenchmark>> benchmarks = {};
    benchmarks.push_back(std::make_shared<FibonacciArray>());
    benchmarks.push_back(std::make_shared<FibonacciRecursive>());
    benchmarks.push_back(std::make_shared<FourierTransform>());
    benchmarks.push_back(std::make_shared<PowCosine>());
    benchmarks.push_back(std::make_shared<QuakeInverseSqrt>());
    benchmarks.push_back(std::make_shared<SquareRoot>());

    const auto epoch = std::chrono::high_resolution_clock::now().time_since_epoch();
    const std::size_t epoch_seconds = std::chrono::duration_cast<std::chrono::seconds>(epoch).count();

    char buffer[2048] = {};

    std::snprintf(buffer, sizeof(buffer), "cxx.%s.%s.main.%zu.csv", PLATFORM, CONFIGURATION, epoch_seconds);
    FILE *file = fopen(buffer, "w");
    assert(file != nullptr);

    std::fprintf(file, "Name,Iterations,Elapsed\n");

    std::vector<double> timings = {};
    for(std::shared_ptr<BaseBenchmark> &benchmark : benchmarks) {
        double elapsed = benchmark->run_benchmark(timings);
        std::size_t iterations = benchmark->max_iterations();
        const char *name = benchmark->name();

        std::fprintf(stderr, "%-25s: %.09fms\n", name, elapsed);
        std::fprintf(file, "%s,%zu,%.012f\n", name, iterations, elapsed);

        std::snprintf(buffer, sizeof(buffer), "cxx.%s.%s.bench.%s.%zu.csv", PLATFORM, CONFIGURATION, name, epoch_seconds);
        FILE *csv = fopen(buffer, "w");
        assert(csv != nullptr);

        std::fprintf(csv, "Iteration,ET\n");

        for(std::size_t i = 0; i < timings.size(); ++i) {
            std::fprintf(csv, "%zu,%.012f\n", i, timings[i]);
        }

        fclose(csv);
    }

    fclose(file);

    return 0;
}
