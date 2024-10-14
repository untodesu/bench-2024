#pragma once
#include "basebenchmark.h"

class FourierTransform final : public BaseBenchmark {
public:
    virtual ~FourierTransform(void) = default;
    virtual std::size_t max_iterations(void) const override { return 5120; }
    virtual const char *name(void) const override { return "FourierTransform"; }

    constexpr static std::size_t NUM_SAMPLES = 1024;
    constexpr static double SAMPLE_RATE = 1024.0;

    std::array<double, NUM_SAMPLES> m_Samples {};
    std::array<double, NUM_SAMPLES> m_FourierRe {};
    std::array<double, NUM_SAMPLES> m_FourierIm {};

    virtual std::uint64_t perform_task(std::random_device &random) override {
        std::uniform_real_distribution<double> dist(-1.0, 1.0);

        for(std::size_t i = 0; i < NUM_SAMPLES; ++i) {
            m_Samples[i] = dist(random);
        }

        for(std::size_t i = 0; i < NUM_SAMPLES; ++i) {
            m_FourierRe[i] = 0.0;
            m_FourierIm[i] = 0.0;

            for(std::size_t j = 0; j < NUM_SAMPLES; ++j) {
                m_FourierRe[i] += std::cos(2.0 * M_PI * i * static_cast<double>(j) / SAMPLE_RATE) * m_Samples[j];
                m_FourierIm[i] += std::sin(2.0 * M_PI * i * static_cast<double>(j) / SAMPLE_RATE) * m_Samples[j];
            }

            m_FourierRe[i] /= 2.0 * SAMPLE_RATE;
            m_FourierIm[i] /= 2.0 * SAMPLE_RATE;
        }

        return UINT64_C(0);
    }
};
