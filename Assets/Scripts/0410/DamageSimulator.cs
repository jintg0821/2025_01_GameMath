using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Weapon
{
    DAGGER,
    LONG_SWORD,
    AXE
}

public class DamageSimulator : MonoBehaviour
{
    public int totalHits = 0;
    public int critHits = 0;
    public float targetRate = 0.1f;

    public int level = 1;
    public int damage;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI totalHitsText;
    public TextMeshProUGUI critHitsText;
    public TextMeshProUGUI levelText;

    private Weapon currentWeapon = Weapon.DAGGER;

    public bool RollCrit(int weapon)
    {
        totalHits++;
        currentWeapon = (Weapon)weapon;

        float baseDamage = level * 20f;
        float stdDev = 0f;
        float critChance = 0f;
        float critMultiplier = 1f;

        switch (currentWeapon)
        {
            case Weapon.DAGGER:
                stdDev = baseDamage * 0.1f;
                critChance = 0.4f;
                critMultiplier = 1.5f;
                break;
            case Weapon.LONG_SWORD:
                stdDev = baseDamage * 0.2f;
                critChance = 0.3f;
                critMultiplier = 2.0f;
                break;
            case Weapon.AXE:
                stdDev = baseDamage * 0.3f;
                critChance = 0.2f;
                critMultiplier = 3.0f;
                break;
        }

        float u1 = 1.0f - Random.value;
        float u2 = 1.0f - Random.value;
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);
        float finalDamage = Mathf.Max(1f, baseDamage + stdDev * randStdNormal);

        float currentRate = critHits > 0 ? (float)critHits / totalHits : 0f;

        if (currentRate < critChance && (float)(critHits + 1) / totalHits <= critChance)
        {
            Debug.Log("Critical Hit! (Forced)");
            critHits++;
            finalDamage *= critMultiplier;
            damage = Mathf.RoundToInt(finalDamage);
            return true;
        }

        if (currentRate > critChance && (float)critHits / totalHits >= critChance)
        {
            Debug.Log("Normal Hit! (Forced)");
            damage = Mathf.RoundToInt(finalDamage);
            return false;
        }

        if (Random.value < critChance)
        {
            Debug.Log("Critical Hit! (Base Chance)");
            critHits++;
            finalDamage *= critMultiplier;
            damage = Mathf.RoundToInt(finalDamage);
            return true;
        }

        Debug.Log("Normal Hit! (Base Chance)");
        damage = Mathf.RoundToInt(finalDamage);
        return false;
    }

    public void SimulateCritical(int weapon)
    {
        RollCrit(weapon);
        damageText.text = damage.ToString();
        critHitsText.text = critHits.ToString();
        totalHitsText.text = totalHits.ToString();
        Debug.Log("Total Hits : " + totalHits);
        Debug.Log("Critical Hits : " + critHits);
        Debug.Log("Current Critical Rate : " + (float)critHits / totalHits);
    }

    public void LevelUP()
    {
        level++;
        Debug.Log($"현재 레벨 : {level}");
    }    
}
