using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public abstract class Weapon : MonoBehaviour 
{
    protected int damage; //Weapon Damage Value
    protected int crit; //Weapon Crit Value
    protected Random critChance;

    public Text combatbox; //Dialogue Box for Combat Information

    // Start is called before the first frame update
    void Start()
    {
        //critChance = new Random();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Current Melee Combat Code, On Collision with Object Checks Tag and Gets Appropriate Reaction
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit Object"); //Testing Only

        if (other.gameObject.tag == "Enemy")
        {
            if (doesCrit())
            {
                //Performs a Critical Hit on the Enemy
                combatbox.text = "Skeleton was Critically Hit for " + crit + " Damage!";
                other.GetComponent<SkeletonEnemy>().TakeDamage(crit);
            }
            else
            {
                //Damage the Enemy
                combatbox.text = "Skeleton was Hit for " + damage + " Damage";
                other.GetComponent<SkeletonEnemy>().TakeDamage(damage);
            }

        } 
        else if (other.gameObject.tag == "NPC")
        {
            //Get Appropriate NPC Response
            transform.root.GetComponent<Player>().menuCanvas.GetComponent<Inventory>().removeItemfromInventory("Gold");
            combatbox.text = "Don't Hit the Townspeople!, You've Been Fined 1 Gold Piece";
        }
        else if (other.gameObject.tag == "Enviroment")
        {
            combatbox.text = "You Scored a Devastating Hit On That Wooden Post";
        }
    }

    public virtual bool doesCrit()
    {
        return false;
    }

}
