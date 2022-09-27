using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private bool isPlaying;

    private float timer;
    private float totalTimer;
    private int score;
    private int totalScore;
    private int totalRetries;

    private void Start()
    {
        StartLevel();
    }

    private void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;
            Toolbox.GetInstance().GetUIManager().SetTimerText((int)timer);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        Toolbox.GetInstance().GetUIManager().SetScoreText(score);
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0;
        isPlaying = false;
    }

    private void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        isPlaying = true;
    }

    public void StartLevel()
    {
        score = 0;
        Toolbox.GetInstance().GetUIManager().SetScoreText(score);
        timer = 0;
        Toolbox.GetInstance().GetUIManager().SetTimerText((int)timer);

        Toolbox.GetInstance().GetUIManager().ShowHud(true);
        Resume();
    }

    public void PauseLevel()
    {
        Toolbox.GetInstance().GetUIManager().ShowPauseOverlay(true);
        Pause();
    }

    public void ResumeLevel()
    {
        Toolbox.GetInstance().GetUIManager().ShowPauseOverlay(false);
        Resume();
    }

    public void WinLevel()
    {
        totalScore += score;
        totalTimer += timer;

        Toolbox.GetInstance().GetUIManager().ShowWinOverlay(true);
        Toolbox.GetInstance().GetUIManager().ShowHud(false);
        Pause();
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Toolbox.GetInstance().GetUIManager().ShowWinOverlay(false);
        SceneManager.LoadScene(nextSceneIndex);
        if(SceneManager.GetSceneByBuildIndex(nextSceneIndex).name != "End")
        {
            StartLevel();
        }
        else
        {
            EndGame();
        }
    }

    public void LoseLevel()
    {
        Toolbox.GetInstance().GetUIManager().ShowRetryOverlay(true);
        Toolbox.GetInstance().GetUIManager().ShowHud(false);
        Pause();
    }

    public void RetryLevel()
    {
        Toolbox.GetInstance().GetUIManager().ShowRetryOverlay(false);

        totalRetries++;
        StartLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        Toolbox.GetInstance().GetUIManager().ShowEndOverlay(true);

        Toolbox.GetInstance().GetUIManager().SetTotalScoreText(totalScore);
        Toolbox.GetInstance().GetUIManager().SetTotalTimerText((int)totalTimer);
        Toolbox.GetInstance().GetUIManager().SetTotalRetriesText(totalRetries);
    }

    public void QuitLevel()
    {
        Toolbox.GetInstance().Unload();

        SceneManager.LoadScene(0);
    }
}
