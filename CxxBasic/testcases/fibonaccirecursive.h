#pragma once
#include "basebenchmark.h"

class FibonacciRecursive final : public BaseBenchmark {
public:
    virtual ~FibonacciRecursive(void) = default;
    virtual std::size_t max_iterations(void) const override { return 5120; }
    virtual const char *name(void) const override { return "FibonacciRecursive"; }

    static std::uint64_t fib(std::uint64_t order) {
        if(order <= UINT64_C(1))
            return order;
        return fib(order - 1) + fib(order - 2);
    }

    virtual std::uint64_t perform_task(std::random_device &random) override {
        // std::uniform_int_distribution<std::uint64_t> dist(0, 20);
        // return fib(dist(random));
        return fib(20);
    }
};
