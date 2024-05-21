/*
* Author: Leong Jia Zhe
* Date:01-05-2024
* Description: code for player info
*/

using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public Respawn RestartGame; 
    public int health = 100;
    public bool hasCollectible1 = false;
    public bool hasCollectible2 = false;
    public bool hasCollectible3 = false;
    public bool hasCollectible4 = false;
    public bool hasKey = false;
    public bool hasGun = false;

    // Check if the player has died
    public bool IsDead()
    {
        return health <= 0;
    }

    public void CollectGun()
    {
        hasGun = true;
        Debug.Log("gun has been collected");
    }


    // Function to collect collectible 1
    public void CollectCollectible1()
    {
        hasCollectible1 = true;
        updateCollectible(1);

    }

    // Function to collect collectible 2
    public void CollectCollectible2()
    {
        hasCollectible2 = true;
        updateCollectible(2);

    }

    // Function to collect collectible 3
    public void CollectCollectible3()
    {
        hasCollectible3 = true;
        updateCollectible(3);
    }

    // Function to collect collectible 4
    public void CollectCollectible4()
    {
        hasCollectible4 = true;
        updateCollectible(4);
    }

    public void updateCollectible(int collectibleNumber)
    {
        GUI gui = gameObject.GetComponent<GUI>();
        // Determine the collected status based on the collectible number
        bool collected = false;
        switch (collectibleNumber)
        {
            case 1:
                collected = hasCollectible1;
                break;
            case 2:
                collected = hasCollectible2;
                break;
            case 3:
                collected = hasCollectible3;
                break;
            case 4:
                collected = hasCollectible4;
                break;
            default:
                Debug.LogWarning("Invalid collectible number: " + collectibleNumber);
                return;
        }
        // Update the collectible GUI with the collectible number and its collected status
        gui.UpdateCollectibleGUI(collectibleNumber - 1, collected);
    }

    // Check if the player has collected all collectibles
    public bool HasAllCollectibles()
    {
        return hasCollectible1 && hasCollectible2 && hasCollectible3 && hasCollectible4;
    }

    // Function to set the key section
    public void SetKeySection(bool value)
    {
        hasKey = value;
        GUI gui = gameObject.GetComponent<GUI>();
        gui.UpdateKeyGUI();
    }

    // Function to reset all keys to false when the player dies
    public void ResetKeys()
    {
        hasCollectible1 = false;
        hasCollectible2 = false;
        hasCollectible3 = false;
        hasCollectible4 = false;
        hasKey = false;
        Debug.Log("All keys reset to false.");
    }

    // Function to handle player death
    public void PlayerDeath()
    {
        RestartGame.RestartGame();
    }
}
