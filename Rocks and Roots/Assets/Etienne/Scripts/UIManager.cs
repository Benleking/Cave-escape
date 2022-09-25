using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject HUD;
    public GameObject RetryOverlay;
    public GameObject WinOverlay;
    public GameObject PickAxeIcon;
    public GameObject AxeIcon;

    [SerializeField] private TextMeshProUGUI livesTMP;
    [SerializeField] private TextMeshProUGUI timerTMP;
    [SerializeField] private TextMeshProUGUI scoreTMP;

    public void RetryButton()
    {
        Toolbox.GetInstance().GetLevelManager().RetryLevel();
        RetryOverlay.SetActive(false);
    }

    public void ReturnToMainMenuButton()
    {
        Toolbox.GetInstance().GetLevelManager();
        RetryOverlay.SetActive(false);
    }

    public void SetLivesText(int value)
    {
        livesTMP.text = value.ToString();
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
