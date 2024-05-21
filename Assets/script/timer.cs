/*
* Author: Leong Jia Zhe
* Date:08-05-2024
* Description: code for the Countdown timer
*/

using UnityEngine;
using System.Collections;

public class CountdownLogger : MonoBehaviour
{
    public static CountdownLogger Instance; // Singleton instance

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
        }
    }

    public void LogCountdown(float duration, string prefix)
    {
        StartCoroutine(CountdownCoroutine(duration, prefix));
    }

    IEnumerator CountdownCoroutine(float duration, string prefix)
    {
        float timer = duration;
        while (timer > 0f)
        {
            Debug.Log(prefix + timer.ToString("F1"));
            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }
    }
}
