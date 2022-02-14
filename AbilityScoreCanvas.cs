using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScoreCanvas : MonoBehaviour
{
    public void Refresh()
    {
        AbilityScores a_s = GetComponentInParent<AbilityScores>();
        if (a_s)
        {
            // Get each ability score text box
            TMPro.TextMeshProUGUI str = transform.Find("Str").GetComponentInChildren<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI agi = transform.Find("Agi").GetComponentInChildren<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI inte = transform.Find("Int").GetComponentInChildren<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI wis = transform.Find("Wis").GetComponentInChildren<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI cha = transform.Find("Cha").GetComponentInChildren<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI con = transform.Find("Con").GetComponentInChildren<TMPro.TextMeshProUGUI>();

            str.text =  a_s.GetExp("str").ToString();
            agi.text =  a_s.GetExp("agi").ToString();
            inte.text = a_s.GetExp("int").ToString();
            wis.text =  a_s.GetExp("wis").ToString();
            cha.text =  a_s.GetExp("cha").ToString();
            con.text =  a_s.GetExp("con").ToString();
        }
    }
}
