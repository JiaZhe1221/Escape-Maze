/*
* Author: Leong Jia Zhe
* Date:10-05-2024
* Description: code for collectible 1
*/

using UnityEngine;
using System.Collections;

public class CubeTimer : MonoBehaviour
{
    public GameObject countdownButton; // Reference to the button GameObject
    private bool timerRunning = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !timerRunning)
        {

            // Show the countdown button
            countdownButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

} 
