/*
* Author: Leong Jia Zhe
* Date:04-05-2024
* Description: code for creature AI to follow player
*/

using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of movement
    public int damageAmount = 20; // Amount of damage to deduct from player's health

    private NavMeshAgent agent; // Reference to the NavMeshAgent component

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Get reference to NavMeshAgent component

        // Enable obstacle avoidance
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;

        // Set stopping distance to 0 to ensure continuous movement towards the player
        agent.stoppingDistance = 0f;
    }

    void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            // Move towards the player's position
            agent.SetDestination(playerObject.transform.position);
        }
    }

    // Handle collision with the player
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the PlayerInfo component from the player GameObject
            PlayerInfo playerInfo = other.GetComponent<PlayerInfo>();
            if (playerInfo != null)
            {
                // Deduct health from the player
                playerInfo.health -= damageAmount;
                Debug.Log("Player health deducted by " + damageAmount + ". Current health: " + playerInfo.health);
                GUI gui = other.GetComponent<GUI>();
                gui.UpdateHealthGUI(playerInfo.health, 100);

                // Check if the player is dead
                if (playerInfo.IsDead())
                {
                    Debug.Log("Player has died.");
                    playerInfo.PlayerDeath();
                }
            }
        }
    }
}
