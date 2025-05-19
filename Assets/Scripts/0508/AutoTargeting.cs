using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTargeting : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private LayerMask enemyLayer;
    private LinePredict linePredict;

    void Start()
    {
        linePredict = GetComponent<LinePredict>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, enemyLayer))
            {
                target = hit.transform;
                linePredict.endPos = target;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            target = null;
            linePredict.endPos = null;
        }
    }
}
