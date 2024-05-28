using UnityEngine;

public class PlayerFightScript : MonoBehaviour
{
    [SerializeField] Animator animatorAttack;

    public AudioSource Sword;

    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate=2f;
    float nextAttackTime = 0f;
    
    void Update()
    {
        if(Time.time >= nextAttackTime){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                Attack();
                nextAttackTime = Time.time + 1f/attackRate; //Attack Delay
            }
        }
    }

    void Attack(){
        animatorAttack.SetTrigger("Attack");
        Sword.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<EnemyScript>().takeDamage();
        }
        
    }

    void OnDrawGizmosSelected(){

        if(AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}

