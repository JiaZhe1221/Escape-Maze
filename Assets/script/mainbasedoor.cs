/*
* Author: Leong Jia Zhe
* Date:05-05-2024
* Description: code for door close and open timer
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance; // Singleton instance

    public GameObject door;
    public GameObject creaturePrefab; // Prefab of the creature to spawn
    public int creaturesToSpawnOnClose = 30; // Number of creatures to spawn when the door closes
    public float doorOpenDuration = 230f; // 2 minutes in seconds
    public float doorCloseDuration = 30f; // 30 seconds in seconds
    public bool doorOpen = false; // Flag to indicate if the door is open
    public bool doorClose = false; // Flag to indicate if the door is closed
    public float openSpeed = 0.5f;
    public float slideDistance = 10f;

    private List<GameObject> spawnedCreatures = new List<GameObject>(); // List to track spawned creatures

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

    public void StartDoorTimer()
    {
        StartCoroutine(DoorTimerCoroutine());
       
    }

    IEnumerator DoorTimerCoroutine()
    {
        float remainingTime = doorOpenDuration;

        yield return OpenDoor(); // Open the door
        Debug.Log("Door opened for 4 minutes.");
        doorOpen = true;
        doorClose = false;

        // Log the door open countdown
        CountdownLogger.Instance.LogCountdown(doorOpenDuration, "Door open countdown: ");

        DestroySpawnedCreatures(); 

        SpawnFixedCreatures();

        while (remainingTime > 0f)
        {
            // Update the GUI with the remaining time
            GUI.Instance.UpdateTime(remainingTime);

            // Decrease the remaining time
            remainingTime -= Time.deltaTime;

            yield return null;
        }

        yield return CloseDoor(); // Close the door
        Debug.Log("Door closed for 30 seconds.");
        doorOpen = false;
        doorClose = true;

        // Log the door close countdown
        CountdownLogger.Instance.LogCountdown(doorCloseDuration, "Door close countdown: ");

        SpawnRandomCreatures(creaturesToSpawnOnClose);

        float remainingTimeClose = doorCloseDuration;
        while (remainingTimeClose > 0f)
        {
            // Update the GUI with the remaining time
            GUI.Instance.UpdateTime(remainingTimeClose);

            // Decrease the remaining time
            remainingTimeClose -= Time.deltaTime;

            yield return null;
        }
        // Wait for the doorCloseDuration
        yield return new WaitForSeconds(doorCloseDuration);

        // Repeat the process
        StartCoroutine(DoorTimerCoroutine());
    }

    IEnumerator OpenDoor()
    {
        Vector3 startPosition = door.transform.position;
        Vector3 endPosition = startPosition + door.transform.right * slideDistance;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            door.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
    }

    IEnumerator CloseDoor()
    {
        Vector3 startPosition = door.transform.position;
        Vector3 endPosition = startPosition - door.transform.right * slideDistance;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            door.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
    }

    void DestroySpawnedCreatures()
    {
        // Destroy all previously spawned creatures
        foreach (GameObject creature in spawnedCreatures)
        {
            Destroy(creature);
        }

        // Clear the list of spawned creatures
        spawnedCreatures.Clear();
    }

    void SpawnFixedCreatures()
    {
        // Define the fixed spawn locations
        Vector3[] spawnLocations = new Vector3[4];
        spawnLocations[0] = new Vector3(552.4396f, 292.779f, 522.9f);
        spawnLocations[1] = new Vector3(511f, 292.779f, 522.9f);
        spawnLocations[2] = new Vector3(511f, 292.779f, 478.6f);
        spawnLocations[3] = new Vector3(552.4396f, 292.779f, 478.6f);

        // Spawn creatures at each fixed location
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            // Instantiate the creature at the fixed location
            GameObject newCreature = Instantiate(creaturePrefab, spawnLocations[i], Quaternion.identity);
            spawnedCreatures.Add(newCreature); // Add the spawned creature to the list
        }
    }

    void SpawnRandomCreatures(int count)
    {
        // Define the spawn area bounds
        Vector3 minBounds = new Vector3(510f, 292f, 478f); // Minimum bounds for x, y, z axes
        Vector3 maxBounds = new Vector3(553f, 293f, 523f);  // Maximum bounds for x, y, z axes

        // Spawn creatures in random positions within the spawn area
        for (int i = 0; i < count; i++)
        {
            // Generate random positions within the spawn area bounds
            Vector3 randomPosition = new Vector3(
                Random.Range(minBounds.x, maxBounds.x),
                Random.Range(minBounds.y, maxBounds.y),
                Random.Range(minBounds.z, maxBounds.z)
            );

            // Instantiate the creature at the random position
            GameObject newCreature = Instantiate(creaturePrefab, randomPosition, Quaternion.identity);
            spawnedCreatures.Add(newCreature); // Add the spawned creature to the list
        }
    }
}
