using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent (typeof(GameState))]
public class Timer : MonoBehaviour
{
    public int startTime = 300;
    private float passedTime;
    TextMeshProUGUI text;
    
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        passedTime = 0;        
    }
    
    void Update()
    {
        passedTime += Time.deltaTime;

        text.text = string.Format("{0:0}", Mathf.CeilToInt(startTime - passedTime));

        GameState.SetTime(passedTime);

        if (startTime - passedTime < 0) {
            GameState.ResetLevel();
        }
    }
}
