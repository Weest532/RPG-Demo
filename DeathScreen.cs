using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScreen : MonoBehaviour
{
    public GameObject DeathMenuUI;

    public GameObject HealthBar;

    public GameObject player;

    // Update is called once per frame
    void Start()
    {
        DeathMenuUI.SetActive(false);
    }

     void Update()
     {
        if(player.GetComponent<Player>().isDead)
        {
           DeathMenuUI.SetActive(true);
           Pause(); 
        }
        else
        {
            DeathMenuUI.SetActive(false);
        }
    }

    void Pause()
    {
        HealthBar.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Restart()
    {        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Game should close here but is in editor");
        Application.Quit();
    }
}
