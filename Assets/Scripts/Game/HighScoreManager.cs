using System;
using System.Collections.Generic;
using UnityEngine;

public static class HighScoreManager
{
    private static HighScore worstScore;
    private static ScoreListContainer listContainer;

    static HighScoreManager()
    {

        if (PlayerPrefs.HasKey("HighScore"))
        {
            String json = PlayerPrefs.GetString("HighScore");
            listContainer = JsonUtility.FromJson<ScoreListContainer>(json);
            listContainer.Sort();
            UpdateWorst();
        }
        else
        {
            SetInitialScores();
        }
    }

    public static void AddNewScore(String name, float time)
    {
        if (IsNewHighScore(time))
        {
            if (listContainer.scores.Count >= 5)
                listContainer.scores.Remove(worstScore);
            listContainer.scores.Add(new HighScore(name.ToUpper(), Mathf.RoundToInt(time)));
            listContainer.Sort();
            UpdateWorst();
            SaveToPrefs();
        }
    }

    private static void SaveToPrefs()
    {
        String scoresJson = JsonUtility.ToJson(listContainer);
        PlayerPrefs.SetString("HighScore", scoresJson);
    }

    public static void ResetHighScore()
    {
        listContainer = new ScoreListContainer();
        UpdateWorst();
        SaveToPrefs();
    }

    private static void SetInitialScores()
    {
        ScoreListContainer container = new ScoreListContainer();
        container.scores.Add(new HighScore("JOAKIM", 923));

        listContainer = container;

        UpdateWorst();
        SaveToPrefs();
    }

    private static void UpdateWorst()
    {
        worstScore = listContainer.scores.Count > 0 ? listContainer.scores[listContainer.scores.Count - 1] : null;
    }

    public static List<HighScore> GetScores()
    {
        return listContainer.scores;
    }

    public static bool IsNewHighScore(float time)
    {
        return (listContainer.scores.Count < 5 || worstScore == null) ? true : time < worstScore.time;        
    }
}

[Serializable]
public class HighScore : IComparable<HighScore>
{
    public string name;
    public int time;
    public HighScore(String name, int time)
    {
        this.name = name;
        this.time = time;
    }
    public int CompareTo(HighScore other)
    {
        return this.time.CompareTo(other.time);
    }
}

[Serializable]
public class ScoreListContainer
{
    public List<HighScore> scores = new List<HighScore>();
    public void Sort()
    {
        scores.Sort();
    }
}