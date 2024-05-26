using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject Player;

    SpriteRenderer spriteRenderer;
    public Sprite passive, active;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.GetComponent<PlayerDamaged>().CheckpointUpdate(transform.position);
            spriteRenderer.sprite = active;
        }
    }


}
