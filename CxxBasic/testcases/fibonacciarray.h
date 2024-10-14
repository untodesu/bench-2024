#pragma once
#include "basebenchmark.h"

class FibonacciArray final : public BaseBenchmark {
public:
    virtual ~FibonacciArray(void) = default;
    virtual std::size_t max_iterations(void) const override { return 5120; }
    virtual const char *name(void) const override { return "FibonacciArray"; }

    virtual std::uint64_t perform_task(std::random_device &random) {
        // std::uniform_int_distribution<std::uint64_t> dist(0, 20);
        std::uint64_t count = 20; // dist(random);
        std::vector<std::uint64_t> fibs = {};
        fibs.resize(count, UINT64_C(0));

        for(std::size_t i = 0; i < fibs.size(); ++i) {
            if(i == 0) {
                fibs[i] = UINT64_C(0);
                continue;
            }

            if(i == 1) {
                fibs[i] = UINT64_C(1);
                continue;
            }

            fibs[i] = fibs[i - 1] + fibs[i - 2];
        }

        return fibs[count - 1];
    }
};
