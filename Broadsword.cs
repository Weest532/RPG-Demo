using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Broadsword : Weapon
{

    // Start is called before the first frame update
    void Start()
    {
        critChance = new Random();

        //All This Block Requires Refactoring
        damage = 20;
        crit = 30;

        //Prevents Broadsword from Clipping Into Player Collider on Certain Animations, Still Collides with Ground However
        Physics.IgnoreCollision(transform.root.GetComponent<CapsuleCollider>(), this.gameObject.GetComponent<BoxCollider>(), true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool doesCrit()
    {
        if(critChance.Next(0,3) == 2)
        {
            return true;
        } else
        {
            return false;
        }
    }

}
