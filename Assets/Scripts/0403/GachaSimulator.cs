using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaSimulator : MonoBehaviour
{
    public int trials = 100;
    public int[] counts;
    public int count;

    public void OneGacha()
    {
        
    }

    public void TenGacha()
    {
        for (int i = 0; i < trials; i++)
        {
            int result = Random.Range(1, counts.Length + 1);
            counts[result - 1]++;
        }
        for (int i = 0; i < counts.Length; i++)
        {
            float percent = (float)counts[i] / trials * 100f;

            if (percent <= 10)
            {
                Debug.Log("S급" + percent);
            }
            else if (percent <= 20)
            {
                Debug.Log("A급" + percent);
            }
            else if (percent <= 30)
            {
                Debug.Log("B급" + percent);
            }
            else if (percent >= 40)
            {
                Debug.Log("C" + percent);
            }
        }
    }
}
