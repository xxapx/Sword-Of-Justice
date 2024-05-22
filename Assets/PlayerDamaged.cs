using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    int PlayerMaxHealth = 3;
    int Health = 3;
    int currentHealth;
    bool hurt = false;

    [SerializeField] public Animator animator;



    void Start()
    {
        currentHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void takeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            hurt = true;
            currentHealth -= damage;

            animator.SetTrigger("Hurt");
        }

        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        animator.SetBool("Death", true);


    }
}
