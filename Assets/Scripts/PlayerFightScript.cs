using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightScript : MonoBehaviour
{

    [SerializeField] public Animator animatorAttack;

    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDMG = 25;

    public float attackRate=2f;
    float nextAttackTime = 0f;
    
    void Update()
    {
        if(Time.time >= nextAttackTime){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                Attack();
                nextAttackTime = Time.time + 1f/attackRate;
            }
        }
    }

    void Attack(){
        animatorAttack.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy1>().takeDamage(attackDMG);
        }
        
    }

    void OnDrawGizmosSelected(){

        if(AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
