using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScores : MonoBehaviour
{
    public int str = 0;
    public int agi = 0;
    public int inte = 0;
    public int wis = 0;
    public int cha = 0;
    public int con = 0;

    public void IncreaseAllExp(int value)
    {
        IncreaseExp("str", value);
        IncreaseExp("agi", value);
        IncreaseExp("int", value);
        IncreaseExp("wis", value);
        IncreaseExp("cha", value);
        IncreaseExp("con", value);
    }

    public void IncreaseExp(string stat, int value)
    {
        switch (stat)
        {
            case "str":
                str += value;
                break;
            case "agi":
                agi += value;
                break;
            case "int":
                inte += value;
                break;
            case "wis":
                wis += value;
                break;
            case "cha":
                cha += value;
                break;
            case "con":
                con += value;
                break;
            default:
                break;
        }
    }

    public int GetActual(string stat)
    {
        switch (stat)
        {
            case "str":
                return Mathf.CeilToInt((float)str / 10);
            case "agi":
                return Mathf.CeilToInt((float)agi / 10);
            case "int":
                return Mathf.CeilToInt((float)inte / 10);
            case "wis":
                return Mathf.CeilToInt((float)wis / 10);
            case "cha":
                return Mathf.CeilToInt((float)cha / 10);
            case "con":
                return Mathf.CeilToInt((float)con / 10);
            default:
                break;
        }
        return 0;
    }

    public float GetExp(string stat)
    {
        switch (stat)
        {
            case "str":
                return ((float)str / 10);
            case "agi":
                return ((float)agi / 10);
            case "int":
                return ((float)inte / 10);
            case "wis":
                return ((float)wis / 10);
            case "cha":
                return ((float)cha / 10);
            case "con":
                return ((float)con / 10);
            default:
                break;
        }
        return 0;
    }

}
