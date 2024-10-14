#pragma once
#include "basebenchmark.h"

class QuakeInverseSqrt final : public BaseBenchmark {
public:
    virtual ~QuakeInverseSqrt(void) = default;
    virtual std::size_t max_iterations(void) const override { return 5120; }
    virtual const char *name(void) const override { return "QuakeInverseSqrt"; }

    union Hack final {
        std::uint64_t ui;
        double dbl;
    };

    static_assert(sizeof(Hack) == sizeof(std::uint64_t));
    static_assert(sizeof(Hack) == sizeof(double));

    virtual std::uint64_t perform_task(std::random_device &random) {
        std::uniform_real_distribution<double> dist(0.0, 1.0);
        double value = dist(random);
        double xhalf = 0.5 * value;
        
        Hack dti = {};
        dti.dbl = value;
        dti.ui = 0x5FE6EC85E7DE30DA - (dti.ui >> 1UL);

        double result = dti.dbl;
        result = result * (1.5 - (xhalf * result * result));
        result = result * (1.5 - (xhalf * result * result));
        return static_cast<std::uint64_t>(result);
    }
};
