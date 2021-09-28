using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineBasicMultiChannelPerlin perlin;
    public AudioSource rumbleSound;
    private float shakeTimer;
    private float shakeTimerTotal; 
    private float startingIntensity; 
    void Start()
    {
        perlin = GetComponent<CinemachineVirtualCamera>()
            .GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity, float time) {
        rumbleSound.Play();
        perlin.m_AmplitudeGain = intensity;
        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;        
    }

    void Update()
    {
        if (shakeTimer > 0) {
            shakeTimer -= Time.deltaTime;
            
            perlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeTimerTotal));            
        }
    }
}
