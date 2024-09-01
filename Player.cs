using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHealth = 100; //The Health Value of the Player
    public bool isDead; //Bool Used for Setting a Deactivation State
    public Canvas menuCanvas; //Inventory UI Canvas
    bool isInventoryOpen = false; //Bool for Checking If Inventory is Onscreen
    public GameObject DeathScreen;

    public Health_Bar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.setMaxHealth(playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) //Check for No Key Inputs If the Player is Dead
        {
            
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                //Bring Up Inventory
                if (!isInventoryOpen)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    Time.timeScale = 0f;
                    menuCanvas.GetComponent<Inventory>().openInventoryUI();
                    isInventoryOpen = true;
                    transform.GetChild(1).GetComponent<WeaponHandler>().enabled = false;
                } 
                else //Closes Inventory if Already Active
                {
                    Cursor.visible = false; 
                    Cursor.lockState = CursorLockMode.Locked;
                    Time.timeScale = 1f;
                    menuCanvas.GetComponent<Inventory>().closeInventoryUI();
                    isInventoryOpen = false;
                    transform.GetChild(1).GetComponent<WeaponHandler>().enabled = true;
                }
            } 
            if (Input.GetKeyDown(KeyCode.H))
            {
                hit(20);
            }
        }
    }

    //If Player Gets Hit Calculates Damage from Total Health and Checks If the Hit Killed the Player
    public void hit(int damage)
    {
        Debug.Log("Hit for " + damage + " Damage");
        playerHealth -= damage;
        healthBar.SetHealth(playerHealth);
        if (playerHealth <= 0) //If the Player is Dead Set Bool and Disable External Control Scripts
        {
            //Player Dies
            transform.GetChild(1).GetComponent<WeaponHandler>().enabled = false;
            isDead = true;
            // DeathScreen.SetActive(true);
            Debug.Log("isDead = " + isDead); //Testing Only
            Debug.Log("Player is Dead at " + playerHealth + " Health. The Final Hit Dealt " + damage + " Damage."); //Testing Only
            
            //Bring up Death Screen - Not Currently Implemented

        }
    }
}
