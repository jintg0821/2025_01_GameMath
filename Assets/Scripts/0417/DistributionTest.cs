using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributionTest : MonoBehaviour
{
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            float sample = NormalDistribution(50f, 5f);
            Debug.Log($"Normal Sample {i + 1}: {sample:F2}");
        }

        for (int j = 0; j < 10; j++)
        {
            int count = PoissonDistribution(3f);
            Debug.Log($"Minute {j + 1}: {count} events");
        }

        int binomialResult = BinomialDistribution(10, 0.3f);
        Debug.Log($"Successes out of 10 trials: {binomialResult}");

        bool bernoulliResult = BernoulliDistribution(0.2f);
        Debug.Log($"Trial result : {(bernoulliResult ? "Success" : "Fail")}");

        int geometricResult = GeometricDistribution(0.1f);
        Debug.Log($"Tries until first success : {geometricResult}");

        int uniformResult = UniformDistribution(0, 4);
        Debug.Log($"Uniform Sample : {uniformResult}");
    }

    float NormalDistribution(float mean, float stdDev)
    {
        float u1 = Random.value;
        float u2 = Random.value;
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Cos(2.0f * Mathf.PI * u2);
        return mean + stdDev * randStdNormal;
    }

    int PoissonDistribution(float lamda)
    {
        int k = 0;
        float p = 1f;
        float L = Mathf.Exp(-lamda);
        while (p > L)
        {
            k++;
            p *= Random.value;
        }
        return k - 1;
    }

    int BinomialDistribution(int trials, float chance)
    {
        int successes = 0;
        for (int i = 0; i < trials; i++)
        {
            if (Random.value < chance)
                successes++;
        }
        return successes;
    }

    bool BernoulliDistribution(float p)
    {
        return Random.value < p;
    }

    int GeometricDistribution(float p)
    {
        int tries = 1;
        while (Random.value >= p)
        {
            tries++;
        }
        return tries;
    }

    int UniformDistribution(int minInclusive, int maxExclusive)
    {
        return Random.Range(minInclusive, maxExclusive);
    }
}
