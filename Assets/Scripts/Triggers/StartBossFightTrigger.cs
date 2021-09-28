using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossFightTrigger : MonoBehaviour
{
    public GameObject bossObject;
    public GameObject bossMusic;    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {            
            bossObject.SetActive(true);
            bossMusic.SetActive(true);
            
            gameObject.SetActive(false);
        }
    }
}
