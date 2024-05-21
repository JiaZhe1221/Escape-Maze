/*
* Author: Leong Jia Zhe
* Date:12-05-2024
* Description: code for door button 
*/


using System.Collections;
using UnityEngine;

public class door : MonoBehaviour
{
    private bool timerRunning = false;
    public float countdownDuration = 2f; // 5 seconds countdown duration
    public string gameMessage = "Collect all the items and return to the key box to create the escape key!\n\n The door is opening in 5 seconds!";

    // Method to start the countdown
    public void StartCountdown()
    {
        if (!timerRunning)
        {
            // Hide the cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(CountdownCoroutine());
        }
    }

    // Coroutine for the countdown
    private IEnumerator CountdownCoroutine()
    {
        timerRunning = true;

        // Display the game message for a specified duration
        GUI.Instance.DisplayMessage(gameMessage, countdownDuration);

        yield return new WaitForSeconds(countdownDuration);

        // Start the map timer
        GameManager.Instance.StartMapTimer();

        // Start the door timer
        TimerManager.Instance.StartDoorTimer();

        timerRunning = false;
    }
}
