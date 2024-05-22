using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] public Animator animator;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    [SerializeField] Transform player;

    int attackDMG = 1;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Mathf.Abs(transform.position.x - player.position.x);
        if (distToPlayer > attackRange)
        {


        }
    }


    void OnDrawGizmosSelected()
    {

        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
