/*
* Author: Leong Jia Zhe
* Date:03-05-2024
* Description: code for game manager to change the map
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public List<GameObject> maps; // List of maze map GameObjects
    private int currentMapIndex = 0; // Index of the current active map
    public float mapChangeInterval = 120f; // Interval in seconds for changing the map (2 minutes)

    public TimerManager timerManager; // Reference to the TimerManager script

    void Awake()
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

        timerManager = GetComponent<TimerManager>(); // Get the TimerManager component
    }

    void Start()
    {
        // Disable all maps except the first one at the start
        DisableAllMaps();
        maps[currentMapIndex].SetActive(true);
    }

    public void StartMapTimer()
    {
        StartCoroutine(MapTimerCoroutine());
    }

    IEnumerator MapTimerCoroutine()
    {
        while (true)
        {
            Debug.Log("Changing map...");
            // Wait for the specified interval before changing the map
            yield return new WaitForSeconds(mapChangeInterval);

            // Change the map
            ChangeMap();
        }
    }

    void ChangeMap()
    {
        // Disable all maps
        DisableAllMaps();

        // Increment currentMapIndex to switch to the next map
        currentMapIndex++;
        if (currentMapIndex >= maps.Count)
        {
            // If the index is out of bounds, loop back to the beginning
            currentMapIndex = 0;
        }

        // Activate the map at the updated index
        maps[currentMapIndex].SetActive(true);
    }

    void DisableAllMaps()
    {
        // Disable all maps in the list
        foreach (GameObject map in maps)
        {
            map.SetActive(false);
        }
    }
}
