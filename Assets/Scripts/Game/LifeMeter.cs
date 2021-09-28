using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (GameState))]
public class LifeMeter : MonoBehaviour
{    
    public GameObject midRed;
    public GameObject rightRed;
    public GameObject midGrey;
    public GameObject rightGrey;
    
    
    void Update()
    {                
        switch (GameState.health) {
            case 1: setLife1(); break;
            case 2: setLife2(); break;
            case 3: setLife3(); break;
        }
    }

    void setLife1() {
        midGrey.gameObject.SetActive(true);
        rightGrey.gameObject.SetActive(true);
        midRed.gameObject.SetActive(false);
        rightRed.gameObject.SetActive(false);
    }
    void setLife2() {
        setLife1();
        midGrey.gameObject.SetActive(false);
        midRed.gameObject.SetActive(true);
    }

    void setLife3() {
        setLife2();
        rightGrey.gameObject.SetActive(false);
        rightRed.gameObject.SetActive(true);
    }
}
