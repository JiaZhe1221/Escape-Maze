/*
* Author: Leong Jia Zhe
* Date:12-05-2024
* Description: code for collectible4 show
*/


using System.Collections;
using UnityEngine;

public class collectible4manager : MonoBehaviour
{
    public GameObject box; // Reference to the box GameObject
    public GameObject collectible4; // Reference to the collectible4 GameObject
    public float openBoxDuration = 10f; // Duration in seconds to open the box
    private bool boxOpened = false; // Flag to track if the box has been opened

    // Method to start the process after the unlock action
    public void OnUnlock()
    {
        GUI.Instance.UpdateCollectible4Trigger();
        StartCoroutine(OpenBoxAfterDelay());
    }

    IEnumerator OpenBoxAfterDelay()
    {
        yield return new WaitForSeconds(openBoxDuration);

        Debug.Log("Box opened. Collectible 4 is now available for collection.");

        // Disable the box renderer and collider
        box.SetActive(false);
        gameObject.SetActive(false);
        // Enable the collection of collectible4
        collectible4.SetActive(true);

    }
}
