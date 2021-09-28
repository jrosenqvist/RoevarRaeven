using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DropToBossTrigger : MonoBehaviour
{    
    public GameObject stageMusic;
    private CameraShake cameraShake;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            stageMusic.GetComponent<AudioSource>().Stop();
            
            gameObject.SetActive(false);
        }
    }
}
