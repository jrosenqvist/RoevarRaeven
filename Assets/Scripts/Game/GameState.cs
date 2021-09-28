using UnityEngine.SceneManagement;

public static class GameState
{
    public static int health = 3;
    public static float totalPassedTime = 0f;
    public static float currentPassedTime;
    
    public static int DecHealth() {        ;
        return --health;
    }

    public static void IncHealth() {
        if (++health >= 3) health = 3;
    }

    public static void ResetLevel() {
        Scene currentScene = SceneManager.GetActiveScene();
        health = 3;
        SceneManager.LoadScene(currentScene.name);
        totalPassedTime += currentPassedTime;        
    }

    public static void LevelComplete() {
        health = 3;
        totalPassedTime += currentPassedTime;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }    

    public static void SetTime(float time) {
        currentPassedTime = time;
    }

    public static float GetTotalTime() {
        return totalPassedTime;
    }

    public static void ResetTime() {
        totalPassedTime = 0;
    }    
}
