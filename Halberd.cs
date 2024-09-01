using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Halberd : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        critChance = new Random();

        damage = 30;
        crit = 50;

        Physics.IgnoreCollision(transform.root.GetComponent<CapsuleCollider>(), this.gameObject.GetComponent<BoxCollider>(), true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool doesCrit()
    {
        if (critChance.Next(0,10) == 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
