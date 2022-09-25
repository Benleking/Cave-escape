using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private bool isPlaying;

    private int retries;
    private float timer;
    private float totalTimer;
    public int Score;
    public int totalScore;


    private void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;
            Toolbox.GetInstance().GetUIManager().SetTimerText((int)timer);
        }
    }

    public void StartLevel()
    {
        Score = 0;
        timer = 0;

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void EndLevel()
    {
        totalScore += Score;
        totalTimer += timer;
    }

    public void RetryLevel()
    {
        retries++;
        StartLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
