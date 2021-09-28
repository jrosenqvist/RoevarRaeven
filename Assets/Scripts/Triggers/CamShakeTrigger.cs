using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamShakeTrigger : MonoBehaviour
{
    private CameraShake cameraShake;
    public CinemachineVirtualCamera virtualCamera;
    public float shakeTime;
    public float shakeIntensity;
    
    private void Start() {     
        cameraShake = virtualCamera.GetComponent<CameraShake>();        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            cameraShake.ShakeCamera(shakeIntensity, shakeTime);
            gameObject.SetActive(false);
        }
    }
}
