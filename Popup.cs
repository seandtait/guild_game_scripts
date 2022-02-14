using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public float popupTime = 0.8f;
    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(int amount)
    {
        GetComponentInChildren<TMPro.TextMeshPro>().text = amount.ToString();
        StartCoroutine(Init());
    }

    public void SetText(string _text)
    {
        GetComponentInChildren<TMPro.TextMeshPro>().text = _text;
    }
    
    IEnumerator Init()
    {
        float time = 0;
        while (time < popupTime)
        {
            time += Time.deltaTime;
            yield return null;
        }
        DestroyImmediate(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
