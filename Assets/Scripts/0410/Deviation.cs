using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deviation : MonoBehaviour
{
    public int N;
    public int Min;
    public int Max;

    void Start()
    {
        StandardDeviation();
    }

    void StandardDeviation()
    {
        float[] samples = new float[N];
        for (int i = 0; i < N; i++)
        {
            samples[i] = Random.Range(Min, Max);
        }

        float mean = samples.Average();
        float sumOfSquares = samples.Sum(x => Mathf.Pow(x - mean, 2));
        float stdDev = Mathf.Sqrt(sumOfSquares / N);

        Debug.Log($"평균 : {mean}, 표준편차 : {stdDev}"); 
    }
}
