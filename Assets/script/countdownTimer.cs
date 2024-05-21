/*
* Author: Leong Jia Zhe
* Date:12-05-2024
* Description: code for door button countdown
*/


using UnityEngine;
using UnityEngine.UI;

public class CountdownButton : MonoBehaviour
{
    public door door;
    public float countdownDuration = 10f; // 10 seconds countdown duration
    public string gameMessage = "Collect all the items and return to the key box to create the escape key!\n\n The door is opening in 5 seconds!";
    
    private Button button; // Reference to the button component

    private void Start()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<Button>();

        // Add a listener for the button click event
        button.onClick.AddListener(OnButtonClick);
    }

    // Method called when the button is clicked
    private void OnButtonClick()
    {
        
        // Start the countdown in the CubeTimer script
        door.StartCountdown();
        Destroy(gameObject);

    }
}
