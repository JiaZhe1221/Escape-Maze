/*
* Author: Leong Jia Zhe
* Date:07-05-2024
* Description: code for key creator box
*/


using UnityEngine;

public class keyCreator : MonoBehaviour
{
    public PlayerInfo player; // Reference to the PlayerInfo component of the player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the player has all collectibles
            if (player.HasAllCollectibles())
            {
                // Set the key section to true in the player
                player.SetKeySection(true);
                Debug.Log("Key section set to true.");

                // Display a message indicating that the key has been created
                GUI.Instance.DisplayMessage("Key created successfully!", 3f);
            }
            else
            {
                // Display an error message indicating that the player needs all collectibles to create the key
                GUI.Instance.DisplayErrorMessage("You need all collectibles to create the key!", 3f);
                Debug.Log("Player does not have all collectibles.");
            }

        }
    }
}
