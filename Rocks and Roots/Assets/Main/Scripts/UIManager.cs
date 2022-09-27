using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject retryOverlay;
    [SerializeField] private GameObject winOverlay;
    [SerializeField] private GameObject pauseOverlay;
    [SerializeField] private GameObject endOverlay;
    public GameObject PickAxeIcon;
    public GameObject AxeIcon;

    [SerializeField] private TextMeshProUGUI timerTMP;
    [SerializeField] private TextMeshProUGUI scoreTMP;


    [SerializeField] private TextMeshProUGUI totalTimerTMP;
    [SerializeField] private TextMeshProUGUI totalScoreTMP;
    [SerializeField] private TextMeshProUGUI totalRetriesTMP;

    //WinOverlay
    public void ShowWinOverlay(bool value)
    {
        winOverlay.SetActive(value);
    }
    public void NextLevelButton()
    {
        Toolbox.GetInstance().GetLevelManager().NextLevel();
    }

    //RetryOverlay
    public void ShowRetryOverlay(bool value)
    {
        retryOverlay.SetActive(value);
    }
    public void RetryButton()
    {
        Toolbox.GetInstance().GetLevelManager().RetryLevel();
    }

    //PauseOverlay
    public void ShowPauseOverlay(bool value)
    {
        pauseOverlay.SetActive(value);
    }
    public void ContinueButton()
    {
        Toolbox.GetInstance().GetLevelManager().ResumeLevel();
    }

    //EndOverlay
    public void ShowEndOverlay(bool value)
    {
        endOverlay.SetActive(value);
    }
    public void SetTotalScoreText(int value)
    {
        totalScoreTMP.text = "Total Score : " + value.ToString();
    }

    public void SetTotalTimerText(int value)
    {
        totalTimerTMP.text = "Total Timer : " + value.ToString() + " seconds";
    }

    public void SetTotalRetriesText(int value)
    {
        totalRetriesTMP.text = "Total Retries : " + value.ToString();
    }


    public void ReturnToMainMenuButton()
    {
        Toolbox.GetInstance().GetLevelManager().QuitLevel();
    }

    //HUD
    public void ShowHud(bool value)
    {
        hud.SetActive(value);
    }

    public void SetScoreText(int value)
    {
        scoreTMP.text = "Score : "+value.ToString();
    }

    public void SetTimerText(int value)
    {
        timerTMP.text = "Timer : "+value.ToString();
    }
}
