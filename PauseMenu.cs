using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePause = false;

    public GameObject PauseMenuUI;

    public GameObject HealthBar;

    void Start()
    {
        PauseMenuUI.SetActive(GamePause);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GamePause)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        HealthBar.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GamePause = false;
        PauseMenuUI.SetActive(GamePause);
        Time.timeScale = 1f;
    }

    void Pause()
    {
        HealthBar.SetActive(false);
        GamePause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        PauseMenuUI.SetActive(GamePause);
        Time.timeScale = 0f;
    }

    public void LoadMainMenu()
    {
        
        GamePause = false;
        PauseMenuUI.SetActive(GamePause);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Game should close here but is in editor");
        Application.Quit();
    }
}
