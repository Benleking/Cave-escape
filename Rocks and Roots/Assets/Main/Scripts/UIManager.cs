using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject retryOverlay;
    [SerializeField] private GameObject winOverlay;
    [SerializeField] private GameObject pauseOverlay;
    public GameObject PickAxeIcon;
    public GameObject AxeIcon;

    [SerializeField] private TextMeshProUGUI timerTMP;
    [SerializeField] private TextMeshProUGUI scoreTMP;



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
