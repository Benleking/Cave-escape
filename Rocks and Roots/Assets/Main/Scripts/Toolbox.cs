using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Toolbox : MonoBehaviour
{
    private static Toolbox instance;

    public static Toolbox GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("Toolbox");
            instance = go.AddComponent<Toolbox>();
            DontDestroyOnLoad(go);
        }
        return instance;
    }

    public void Unload()
    {
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
    }

    //Managers

    //Level
    private LevelManager levelManager;
    public LevelManager GetLevelManager()
    {
        return levelManager;
    }

    //UI
    private UIManager uiManager;
    public UIManager GetUIManager()
    {
        return uiManager;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Trying to instantiate a second instance of Toolbox");
            Destroy(gameObject);
        }
        else
        {
            if (levelManager == null)
            {

                levelManager = FindObjectOfType<LevelManager>();
                if (levelManager == null)
                {
                    GameObject go = new GameObject("LevelManager");
                    go.transform.parent = transform;
                    levelManager = go.AddComponent<LevelManager>();
                }
            }

            if (uiManager == null)
            {
                uiManager = FindObjectOfType<UIManager>();
                if (uiManager == null)
                {
                    GameObject go = Instantiate(Resources.Load("Prefabs/UI") as GameObject);
                    go.transform.parent = transform;
                    uiManager = go.GetComponent<UIManager>();
                }
            }

        }
    }
}
