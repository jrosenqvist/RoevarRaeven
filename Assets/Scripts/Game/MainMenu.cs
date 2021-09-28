using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    private Transform scoreContainer;
    private Transform scoreTemplate;    
    private List<Transform> scores;
    void Start()
    {        
        Cursor.visible = true;
        scoreContainer = transform.Find("EntryContainer");
        scoreTemplate = scoreContainer.Find("EntryTemplate");
        scores = new List<Transform>();        
        RefreshScoreList();
    }    

    public void RefreshScoreList() {
        scores.ForEach(score =>
        {
            Destroy(score.gameObject);
        });

        scores = new List<Transform>();

        List<HighScore> highScores = HighScoreManager.GetScores();
        
        
        int offset = 60;
        for (int i = 0; i < 5; i++)
        {

            Transform entryTransform = Instantiate(scoreTemplate, scoreContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -(i * 55 + offset));
            TextMeshProUGUI name = entryTransform.Find("Name").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI time = entryTransform.Find("Time").GetComponent<TextMeshProUGUI>();
            Debug.Log(highScores.Count);
            if (i < highScores.Count) {                
                name.text = (i + 1) + ". " + highScores[i].name;
                time.text = TimeSpan.FromSeconds(highScores[i].time).ToString(@"mm\:ss");
            } else {
                name.text = (i + 1) + ". " + "-";
                time.text = "--:--";
            }
            
            entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;                        
            entryTransform.Find("Time").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
            entryTransform.gameObject.SetActive(true);
            scores.Add(entryTransform);
        }        
    }

    public void ResetHighScore() {
        HighScoreManager.ResetHighScore();
        RefreshScoreList();
    }

    public void StartGame()
    {
        GameState.ResetTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
