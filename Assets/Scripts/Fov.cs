using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fov : MonoBehaviour
{
    public Transform player;
    public float viewAngle = 60f;   // 시야각
    public float viewDistance = 10f;

    private UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        Vector3 toPlayer = (player.position - transform.position);
        float distance = toPlayer.magnitude;

        if (distance > viewDistance) return;

        Vector3 forward = transform.forward;
        Vector3 toPlayerDir = toPlayer.normalized;

        float dot = (toPlayerDir.x * forward.x) + (toPlayerDir.y * forward.y) + (toPlayerDir.z * forward.z);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;  // 내적을 각도로 변환

        if (angle < viewAngle / 2)
        {
            uiManager.Die();
        }
    }
}
