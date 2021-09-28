using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public TextMeshProUGUI text;
    bool paused;
    void Start()
    {
        paused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = true;
            Pause();
        }        
        
        if (paused) {
            if (Input.GetKeyDown(KeyCode.Y)) {
                UnPause();
                SceneManager.LoadScene("MainMenu");
                Cursor.visible = true;
            }

            else if (Input.GetKeyDown(KeyCode.N)) {
                paused = false;
                UnPause();
            }
        }
    }

    void Pause()
    {
        text.gameObject.SetActive(true);
        Time.timeScale = 0;        
    }

    void UnPause()
    {
        text.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
