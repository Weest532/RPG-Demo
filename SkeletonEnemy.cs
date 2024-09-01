using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkeletonEnemy : MonoBehaviour
{
    public int enemyHP = 100;

    public Animator animator;

    public GameObject itemToDrop;

    private GameObject player;

    private bool isDead = false;

    public float fadeSpeed;

    private bool DamageCooldown;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        if(animator.GetBool("isAttacking") == true && DamageCooldown == false)
        {
            player.gameObject.GetComponent<Player>().hit(5);
            StartCoroutine(attackCooldown());
        }
    }

    IEnumerator attackCooldown()
    {
        DamageCooldown = true;
        yield return new WaitForSecondsRealtime(1);
        DamageCooldown = false;
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if(enemyHP <= 0)
        {
            StartCoroutine(death());
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }

    IEnumerator death()
    {
        Debug.Log("Enemy dead");
        isDead = true;
        animator.SetTrigger("death");
        GetComponent<CapsuleCollider>().enabled = false;
        itemToDrop = Instantiate(itemToDrop, this.gameObject.transform.position, this.gameObject.transform.rotation);
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
