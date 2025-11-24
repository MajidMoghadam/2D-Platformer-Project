using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    // Detect collision with the Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the colliding object is tagged "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Access the PlayerHealth script and apply damage
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();
        }
    }
}
