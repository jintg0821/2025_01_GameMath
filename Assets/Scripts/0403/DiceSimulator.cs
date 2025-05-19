using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceSimulator : MonoBehaviour
{
    public int[] counts = new int[6];

    public int trials = 100;

    public GameObject textContent;
    public GameObject ImagePrefab;
    public List<GameObject> imagePrefabList;

    public void Dice()
    {
        ClearText();
        for (int i = 0; i < trials; i++)
        {
            int result = Random.Range(1, counts.Length + 1);
            counts[result - 1]++;
        }
        for (int i = 0; i < counts.Length; i++)
        {
            float percent = (float)counts[i] / trials * 100f;
            var imagePref = Instantiate(ImagePrefab, textContent.transform, true);
            TextMeshProUGUI textObj = imagePref.GetComponentInChildren<TextMeshProUGUI>();
            textObj.text = $"{i + 1} : {counts[i]}회 ({percent:F2}%)";
            imagePrefabList.Add(imagePref);
        }
    }

    void ClearText()
    {
        foreach(GameObject imagePrefab in imagePrefabList)
        {
            Destroy(imagePrefab);
        }
        imagePrefabList.Clear();
    }
}
