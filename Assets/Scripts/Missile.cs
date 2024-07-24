using UnityEngine;

public class Missile : MonoBehaviour
{
    public int damage = 10; // Damage dealt by the missile

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the triggered object has the tag "Monk"
        if (other.CompareTag("Monk"))
        {
            // Get the Monkfish component
            Monkfish monk = other.GetComponent<Monkfish>();
            if (monk != null)
            {
                // Deal damage to the player
                monk.TakeDamage(damage);
            }

            // Destroy the missile on trigger
            Destroy(gameObject);
        }
    }
}