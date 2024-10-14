#include "stdafx.h"
#include "basebenchmark.h"

double BaseBenchmark::run_benchmark(std::vector<double> &timings) {
    std::random_device random = {};
    std::chrono::high_resolution_clock clock = {};

    timings.clear();
    timings.resize(max_iterations(), 0.0);

    for(std::size_t i = 0; i < timings.size(); ++i) {
        const auto start = clock.now();
        perform_task(random);
        const auto end = clock.now();
        const auto elapsed = std::chrono::duration_cast<std::chrono::microseconds>(end - start);
        timings[i] = 0.001 * static_cast<double>(elapsed.count());
    }

    return static_cast<double>(std::accumulate(timings.cbegin(), timings.cend(), 0.0)) / static_cast<double>(timings.size());
}
