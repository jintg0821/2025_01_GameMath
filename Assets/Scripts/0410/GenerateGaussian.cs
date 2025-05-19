using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGaussian : MonoBehaviour
{
    public float Mean;
    public float StdDev;

    float Generate(float mean, float stdDev)
    {
        float u1 = 1f - Random.value;
        float u2 = 1f - Random.value;

        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Cos(2.0f * Mathf.PI * u2);

        return mean + stdDev * randStdNormal;
    }

    public void GetRandom()
    {
        Debug.Log(Generate(Mean, StdDev));
    }    
}
