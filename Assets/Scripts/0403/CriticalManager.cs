using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CriticalSimulator : MonoBehaviour
{
    public int totalHits = 0;
    public int critHits = 0;
    public float targetRate = 0.1f; // 10% 목표 확률

    public bool RollCrit()
    {
        totalHits++;
        float currentRate = 0f;
        if (critHits > 0)
        {
            currentRate = (float)critHits / totalHits;
        }

        if (currentRate < targetRate && (float)(critHits + 1) / totalHits <= targetRate)
        {
            Debug.Log("Critical Hit!, (Forced)");
            critHits++;
            return true;    // 치명타가 발생한 이후에도 현재 비율이 여전히 낮다면 무조건 발생시킴
        }

        if (currentRate > targetRate && (float)critHits / totalHits >= targetRate)
        {
            Debug.Log("Normal Hit!, (Forced)");
            return false;   //치명타가 발생한 이후에도 현재 비율이 높다면 무조건 발생시키지 않음
        }

        if (Random.value < targetRate)
        {
            Debug.Log("Critical Hit!, Base");
            critHits++;
            return true;    //기본 확률 처리
        }

        Debug.Log("Normal Hit!, Base");
        return false;
    }

    public void SimulateCritical()
    {
        RollCrit();
        Debug.Log("Total Hits : " + totalHits);
        Debug.Log("Critical Hits : " + critHits);
        Debug.Log("Current Critical Rate : " + (float)critHits / totalHits);
    }
}
