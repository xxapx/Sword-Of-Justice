using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    
    [SerializeField] public Animator animator;

    public int maxHeath = 100;
    int currentHealth;


    void Start()
    {
        currentHealth = maxHeath;
    }

    public void takeDamage(int damage){
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

         if (currentHealth <= 0){
            Dead();
        }
    }


    void Dead(){
        animator.SetBool("Death", true);

        GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 0.01f);
        GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0.06f);

        //GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
   



}
