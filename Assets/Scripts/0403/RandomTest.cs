using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTest : MonoBehaviour
{
    void Start()
    {
        // Unity Random (균등 분포)
        float chance = Random.value;    // 0~1 float
        int dice = Random.Range(1, 7);  // 1~6 int

        // System.Random
        System.Random sysRand = new System.Random();
        int number = sysRand.Next(1, 7);    // 1~6 (int)

        Debug.Log("Unity Random (Random.value) : " + chance);
        Debug.Log("Unity Random (Random.Range) : " + dice);
        Debug.Log("System Random (Next) : " + number);
    }
}
