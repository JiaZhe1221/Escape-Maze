/*
* Author: Leong Jia Zhe
* Date:04-05-2024
* Description: code for UI
*/

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GUI : MonoBehaviour
{
    public static GUI Instance; // Singleton instance

    public TextMeshProUGUI bulletText;
    public TextMeshProUGUI errorMsg;
    public GameObject errorBox;
    public GameObject messageBox;
    public Image healthBar;
    public Image key;
    public Image[] collectibleImages;
    public Image welcomeMsg;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI timer;
    public Image collectible4;
    public Image crossHair;

    private Coroutine errorMessageCoroutine;
    private Coroutine disableWelcomeMsgCoroutine;

    private void Start()
    {
        disableWelcomeMsgCoroutine = StartCoroutine(DisableWelcomeMsgAfterDelay(8f));
    }

    private IEnumerator DisableWelcomeMsgAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Disable the welcome message after the delay
        welcomeMsg.gameObject.SetActive(false);
        crossHair.gameObject.SetActive(true);
    }

    private void Awake()
    {
        // Set up the singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        errorBox.SetActive(false);
        messageBox.SetActive(false);
    }

    public void UpdateGUI(int bulletCount)
    {
        string bulletNum = bulletCount.ToString();
        bulletText.text = "Bullet left: " + bulletNum;
    }

    public void DisplayErrorMessage(string message, float duration)
    {
        errorBox.SetActive(true); // Set the error box active to make it visible
        errorMsg.text = message;
        if (errorMessageCoroutine != null)
        {
            StopCoroutine(errorMessageCoroutine);
        }
        errorMessageCoroutine = StartCoroutine(ClearErrorMessage(duration));

        // Hide the crosshair
        crossHair.gameObject.SetActive(false);
    }

    public void DisplayMessage(string message, float duration)
    {
        messageBox.SetActive(true); // Set the message box active to make it visible
        messageText.text = message;
        StartCoroutine(ClearMessage(duration));

        // Hide the crosshair
        crossHair.gameObject.SetActive(false);
    }

    private IEnumerator ClearErrorMessage(float duration)
    {
        yield return new WaitForSeconds(duration);
        errorMsg.text = "";
        errorBox.SetActive(false); // Deactivate the error box after the duration

        // Show the crosshair
        crossHair.gameObject.SetActive(true);
    }

    private IEnumerator ClearMessage(float duration)
    {
        yield return new WaitForSeconds(duration);
        messageText.text = "";
        messageBox.SetActive(false); // Deactivate the message box after the duration

        // Show the crosshair
        crossHair.gameObject.SetActive(true);
    }

    public void UpdateHealthGUI(int currentHealth, int maxHealth)
    {
        // Calculate the fill amount for the health bar
        float fillAmount = (float)currentHealth / maxHealth;

        // Update the fill amount of the health bar image
        healthBar.fillAmount = fillAmount;
    }

    public void UpdateCollectibleGUI(int collectibleIndex, bool collected)
    {
        if (collectibleIndex >= 0 && collectibleIndex < collectibleImages.Length)
        {
            // Change the color of the collectible image based on its collected status
            collectibleImages[collectibleIndex].color = collected ? Color.white : Color.gray;
        }
    }

    public void UpdateTime(float timeRemaining)
    {
        // Update the timer text with the remaining time formatted as minutes and seconds
        string time = string.Format("{0}:{1:00}", Mathf.FloorToInt(timeRemaining / 60), Mathf.FloorToInt(timeRemaining % 60));
        timer.text = "Time left: " + time;
    }

    public void UpdateKeyGUI()
    {
        key.color = Color.white;
    }

    public void UpdateCollectible4Trigger()
    {
        // Display the message for 3 seconds
        DisplayMessage("You've entered the collectible area. Wait for 10 seconds to open the box.", 3f);
    }
}
