using UnityEngine;

public class CreatureHealth : MonoBehaviour
{
    public int health = 100; // Creature health

    // Function to decrease creature's health
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Creature health deducted by " + damageAmount + ". Current health: " + health);
        if (health <= 0)
        {
            Debug.Log("Creature Die");
            Destroy(gameObject);
        }
    }
}
