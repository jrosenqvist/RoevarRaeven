using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour {
    private bool highScore;
    Transform highScoreCanvas;
    float totalTime;
    private void Start() {       
        Cursor.visible = true;
        totalTime = GameState.GetTotalTime();
        highScoreCanvas = transform.Find("HighScore");
        highScoreCanvas.gameObject.SetActive(false);
        Transform timeTransform = transform.Find("Time");
        timeTransform.GetComponent<TextMeshProUGUI>().text = TimeSpan.FromSeconds(totalTime).ToString(@"mm\:ss");
        
        if (HighScoreManager.IsNewHighScore(totalTime)) {
            highScore = true;
            highScoreCanvas.gameObject.SetActive(true);
        }        
        
    }

    public void PressOK() {
        if (highScore) {
            Transform input = highScoreCanvas.Find("Input");
            String text = input.GetComponent<TMP_InputField>().text;
            if (text.Length < 1) 
                return;
            HighScoreManager.AddNewScore(text, totalTime);
        }
        SceneManager.LoadScene(0);
    }
}