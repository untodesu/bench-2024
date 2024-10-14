#pragma once
#include "basebenchmark.h"

class SquareRoot final : public BaseBenchmark {
public:
    virtual ~SquareRoot(void) = default;
    virtual std::size_t max_iterations(void) const override { return 5120; }
    virtual const char *name(void) const override { return "SquareRoot"; }

    virtual std::uint64_t perform_task(std::random_device &random) {
        std::uniform_real_distribution<double> dist(0.0, 1.0);
        return static_cast<std::uint64_t>(std::sqrt(dist(random)));
    }
};
