using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start() {                
        slider.value = PlayerPrefs.GetFloat("volumeSlider", 1f);
    }
    
    public void SetVolume(float sliderValue) {
        mixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("volumeSlider", sliderValue);
    }
}
