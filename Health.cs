using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int value;
    public int max;

    public float GetHpRatio()
    {
        return (float)value / (float)max;
    }

    public int TakeDamage(int amount)
    {
        value -= amount;
        Validate();
        return amount;
    }

    public int Heal(int amount)
    {
        value += amount;
        Validate();
        return amount;
    }

    void Validate()
    {
        if (value < 0)
        {
            value = 0;
        }
        if (value > max)
        {
            value = max;
        }
        SetVisibleHPGauge();
        if (value == 0)
        {
            Guild.instance.KillHero(gameObject);
        }
    }

    public void SetVisibleHPGauge()
    {
        Health _h = GetComponent<Health>();
        Image[] _images = GetComponentsInChildren<Image>();
        foreach (var image in _images)
        {
            if (image.CompareTag("HPGauge"))
            {
                image.GetComponent<RectTransform>().sizeDelta = new Vector2(_h.GetHpRatio(), 0);
            }
        }
    }

}
