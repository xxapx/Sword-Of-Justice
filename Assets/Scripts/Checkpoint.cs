using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject Player;
    public AudioSource Check;
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
            Check.Play();
            Player.GetComponent<PlayerDamaged>().CheckpointUpdate(transform.position);
            spriteRenderer.sprite = active;
            GetComponent<Collider2D>().enabled = false;
        }
    }


}
