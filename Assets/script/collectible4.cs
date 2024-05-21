/*
* Author: Leong Jia Zhe
* Date:12-05-2024
* Description: code for collectible4 trigger area
*/


using UnityEngine;
using System.Collections;

public class Collectible4Area : MonoBehaviour
{
    private bool boxOpened = false; // Flag to track if the box has been opened
    public GameObject unlockButton; // Reference to the button GameObject
    public PlayerInfo player;
    public bool playerGun = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !boxOpened)
        {
            PlayerInfo playerInfo = other.GetComponent<PlayerInfo>();
            if(playerInfo.hasGun == true)
            {
                playerInfo.hasGun = false;
                playerGun = true;
            }
            Debug.Log("Player entered the collectible4 area.");
            unlockButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Destroy(gameObject);
        }
    }

    
}
