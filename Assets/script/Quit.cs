/*
* Author: Leong Jia Zhe
* Date:14-05-2024
* Description: code for exit game button
*/


using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    // When button press Exit the game to unity editor
    public void ExitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}

