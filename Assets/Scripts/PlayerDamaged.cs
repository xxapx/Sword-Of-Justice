using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    int PlayerMaxHealth = 3;
    int Health = 6;
    int currentHealth;
    bool hurt = false;

    public bool isDead = false;

    [SerializeField] public Animator animator;




    void Start()
    {
        currentHealth = Health;
    }

    public bool takeDamage(int damage)
    {
        
        if (currentHealth > 0)
        {
            hurt = true;
            currentHealth -= damage;
            Debug.Log("Damage current health:  " + currentHealth);
            animator.SetTrigger("Hurt");

        }

        if (currentHealth <= 0) { 
            Dead();
            isDead = true;
            GetComponent<PlayerControl>().enabled = false;
            GetComponent<PlayerFightScript>().enabled = false;
        }

        return isDead;
    }

    void Dead()
    {
        Debug.Log("dead");
        animator.SetBool("Death", true);
    }
}
