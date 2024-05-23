using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] public Animator animator;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    [SerializeField] Transform player;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    int attackDMG = 1;
   
     public void AttackPlayer(int attackDMG)
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerDamaged>().takeDamage(attackDMG);
        }
        nextAttackTime = Time.time + 1f / attackRate;
    }


    void OnDrawGizmosSelected()
    {

        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
