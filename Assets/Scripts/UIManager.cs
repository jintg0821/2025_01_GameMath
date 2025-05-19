using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI destinationText;
    public TextMeshProUGUI text;
    public GameObject GameOverPanel;
    public Transform destination;
    public Transform startPoint;

    void Update()
    {
        Vector3 toDestniation = transform.position - destination.position;
        float distance = toDestniation.magnitude;
        destinationText.text = $"도착지까지 남은 거리 : {distance}";
    }

    public void Die()
    {
        UpdateUI("교도관에게 걸렸습니다");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Destination")
        {
            UpdateUI("축하합니다~");
        }
    }

    public void UpdateUI(string message)
    {
        GameOverPanel.SetActive(true);
        text.text = message;
        transform.position = startPoint.position;
    }
}
