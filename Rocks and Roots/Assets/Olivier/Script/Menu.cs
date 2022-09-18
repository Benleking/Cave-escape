using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void StartButton() 
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        //UIManager.Instance.DeathCounter = 0;
        //UIManager.Instance.CoinTracker = 0;
        //UIManager.Instance.Timer = 0f;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        //UIManager.Instance.CoinTracker = 0;
        Time.timeScale = 1f;
    }

    public void QuitButton() 
    {
        Application.Quit();
    }

    public void PlayAgainButton() 
    {
        //UIManager.Instance.DeathCounter = 0;
        //UIManager.Instance.CoinTracker = 0;
        //UIManager.Instance.Timer = 0f;
        
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
