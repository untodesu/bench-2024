#pragma once

class BaseBenchmark {
public:
    virtual ~BaseBenchmark(void) = default;
    virtual std::size_t max_iterations(void) const = 0;
    virtual const char *name(void) const = 0;
    virtual std::uint64_t perform_task(std::random_device &random) = 0;
    double run_benchmark(std::vector<double> &timings);
};
