using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTest : MonoBehaviour
{
    public Transform target;    // 목표 위치

    void Update()
    {
        Vector3 playerForward = transform.forward;
        Vector3 toTarget = (target.position - transform.position).normalized;

        if (IsLeft(playerForward, toTarget, Vector3.up))
        {
            Debug.Log("타겟이 플레이어 기준 왼쪽에 있음");
        }
        else
        {
            Debug.Log("타겟이 플레이어 기준 오른쪽에 있음");
        }
    }

    bool IsLeft(Vector3 forward, Vector3 targetDirection, Vector3 up)
    {
        Vector3 cross = new Vector3((forward.y * targetDirection.z) - (forward.z * targetDirection.y),
            (forward.z * targetDirection.x) - (forward.x * targetDirection.z),
            (forward.x * targetDirection.y) - (forward.y * targetDirection.x));
        return Vector3.Dot(cross, up) < 0;
    }
}
