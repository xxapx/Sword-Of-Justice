using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPlayer : MonoBehaviour
{
    [SerializeField] GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Player.GetComponent<PlayerDamaged>().isDead == false)
            {
                Player.GetComponent<PlayerDamaged>().takeDamage(1);
            }
            else
            {
                this.enabled = false;
            }
        }
    }
}
