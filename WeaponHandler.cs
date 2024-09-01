using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    Animator animator; //Weapon Animator
    public GameObject equippedWeapon; //Currently Equipped Weapon GameObject
    GameObject[] weaponList; //List of Available Weapon GameObjects
    public Player player; //Player Object
    bool unequipped = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = equippedWeapon.GetComponent<Animator>();

        //Initialises the Weaponlist by Finding the Weapon GameObjects the Player Uses
        weaponList = new GameObject[] { GameObject.FindWithTag("Broadsword"), 
            GameObject.FindWithTag("Zweihander") , GameObject.FindWithTag("Halberd") };
        
        //If a Weapon Option is Not Equiped on Startup Deactivate It
        foreach (GameObject weapon in weaponList)
        {
            if(weapon != equippedWeapon)
            {
                weapon.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) //Weapon Primary Attack
        {
            switch (equippedWeapon.tag) //Plays a Set Animation Depending on the Weapon Type Currently Equipped
            {
                case "Broadsword":
                    animator.Play("Sword-Swing");
                    break;
                case "Zweihander":
                    animator.Play("Zweihander-Swing");
                    break;
                case "Halberd":
                    animator.Play("Halberd-Swing");
                    break;
                default:
                    Debug.Log("No Valid Weapon Equipped");
                    break;
            }

            //Swing Weapon
            //animator.SetTrigger("SwingAttack");
            //animator.ResetTrigger("SwingAttack");
            //animator.Play("Sword-Swing");

        }
        else if (Input.GetMouseButton(1)) //Weapon Secondary Attack
        {
            switch (equippedWeapon.tag)
            {
                case "Broadsword":
                    animator.Play("Sword-Pierce");
                    break;
                case "Zweihander":
                    animator.Play("Zweihander-Strike");
                    break;
                case "Halberd":
                    animator.Play("Halberd-Push");
                    break;
                default:
                    Debug.Log("No Valid Weapon Equipped");
                    break;
            }

            //Pierce Weapon
            //animator.SetTrigger("PierceAttack");
            //animator.ResetTrigger("PierceAttack");
            //animator.Play("Sword-Pierce");

        }
        else if (Input.GetKeyDown(KeyCode.E)) //Put Weapon Away
        {
            StartCoroutine(disableWeapon());
        }
        else if (Input.GetKeyDown(KeyCode.R)) //Equip Weapon
        {
            enableWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1)) //Number Key 1
        {
            if (unequipped)
            {
                Debug.Log("Cannot Equip Broadsword When Your Weapon is Stowed Away");
            }
            else
            {
                //Swap to Sword
                resetWeapons("Broadsword");
                equippedWeapon.SetActive(true);
                equippedWeapon.tag = "Broadsword";
                enableWeapon();
                refreshWeapons();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) //Number Key 2
        {
            if (unequipped)
            {
                Debug.Log("Cannot Equip Zweihander When Your Weapon is Stowed Away");
            }
            else
            {
                //Swap to Zweihander
                resetWeapons("Zweihander");
                equippedWeapon.tag = "Zweihander";
                equippedWeapon.SetActive(true);
                enableWeapon();
                refreshWeapons();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) //Number Key 3
        {
            //Swap to Halberd
            if (unequipped)
            {
                Debug.Log("Cannot Equip Halberd When Your Weapon is Stowed Away");
            }
            else
            {
                resetWeapons("Halberd");
                equippedWeapon.tag = "Halberd";
                equippedWeapon.SetActive(true);
                enableWeapon();
                refreshWeapons();
            }
        }
    }

    void resetWeapons(string weaponType) 
    {
        for(int i = 0; i < weaponList.Length; i++)

        {

            if (weaponList[i].tag.Equals(weaponType))
            {
                equippedWeapon = weaponList[i];
                animator = equippedWeapon.GetComponent<Animator>();
            }

        }
    }

    //Cycles Through Each GameObject weapon in weaponList and Deactivates Any Active Unequipped Weapons
    void refreshWeapons()
    {
        foreach (GameObject weapon in weaponList)
        
        {
            if (weapon != equippedWeapon)
            {
                weapon.SetActive(false);
            } 
        }
    }

    //Disables the Current Weapon After Waiting a Set Real Time and Playing It's Unequip Animation
    IEnumerator disableWeapon()
    {

        Debug.Log("Running disableWeapon IEnum");

        switch (equippedWeapon.tag)
        {
            case "Broadsword":
                animator.Play("Sword-Sheath");
                break;
            case "Zweihander":
                animator.Play("Zweihander-Sheath");
                break;
            case "Halberd":
                animator.Play("Halberd-Discard");
                break;
            default:
                Debug.Log("No Valid Weapon Equipped");
                break;
        }

        yield return new WaitForSecondsRealtime(1);
        animator.enabled = false;
        equippedWeapon.SetActive(false);
        unequipped = true;
    }

    //Enables the Currently Equipped Weapon and Plays it's Specific Equip Animation
    void enableWeapon()
    {
        equippedWeapon.SetActive(true);
        animator.enabled = true;
        unequipped = false;

        switch (equippedWeapon.tag)
        {
            case "Broadsword":
                animator.Play("Sword-Equip");
                break;
            case "Zweihander":
                animator.Play("Zweihander-Equip");
                break;
            case "Halberd":
                animator.Play("Halberd-Equip");
                break;
            default:
                Debug.Log("No Valid Weapon Equipped");
                break;
        }
    }
}
