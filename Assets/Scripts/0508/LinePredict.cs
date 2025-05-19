using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LinePredict : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;

    [Range(1f, 5f)] public float extend = 1.5f;

    private LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.widthMultiplier = 0.05f;
        lr.material = new Material(Shader.Find("Unlit/Color"))
        {
            color = Color.cyan
        };
    }

    void Update()
    {
        if (endPos != null)
        {
            lr.enabled = true;
            if (!startPos || !endPos) return;
            Vector3 a = startPos.position;
            Vector3 b = endPos.position;
            Vector3 pred = Vector3.LerpUnclamped(a, b, extend);
            lr.SetPosition(0, a);
            lr.SetPosition(1, pred);
        }
        else
        {
            lr.enabled = false;
        }
    }
}
