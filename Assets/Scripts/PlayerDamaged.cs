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

    public bool deadTrue;



    void Start()
    {
        currentHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool takeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            hurt = true;
            currentHealth -= damage;

            animator.SetTrigger("Hurt");
            deadTrue = false;
        }

        if (currentHealth <= 0)
        {
            Dead();
            deadTrue = true;
        }
        return deadTrue;
    }

    void Dead()
    {
        animator.SetBool("Death", true);
    }
}
