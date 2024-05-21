/*
* Author: Leong Jia Zhe
* Date:12-05-2024
* Description: code for collectible4 unlock button
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectible4Button : MonoBehaviour
{
    public collectible4manager collectible4;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    // Method called when the button is clicked
    private void OnButtonClick()
    {
        // Hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // Call the method to start the coroutine in collectible4manager
        collectible4.OnUnlock();

        // Destroy the button after it's clicked
        Destroy(gameObject);
    }
}
