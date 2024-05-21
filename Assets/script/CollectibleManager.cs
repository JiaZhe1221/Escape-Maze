/*
* Author: Leong Jia Zhe
* Date:07-05-2024
* Description: code for generate collectibles
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public List<GameObject> collectiblePrefabs; // List of collectible key prefabs
    public int totalCollectibles = 10; // Total number of collectibles to generate
    public Vector3 minBounds; // Minimum bounds for collectible spawn area
    public Vector3 maxBounds; // Maximum bounds for collectible spawn area
    public LayerMask obstacleLayer; // Layer mask for obstacles (e.g., walls)

    void Start()
    {
        GenerateCollectibles();
    }

    void GenerateCollectibles()
    {
        // Calculate the number of collectibles needed for each type
        int collectiblesPerType = totalCollectibles / collectiblePrefabs.Count;
        int remainingCollectibles = totalCollectibles % collectiblePrefabs.Count;

        // Shuffle the list of collectible prefabs
        ShuffleList(collectiblePrefabs);

        // Generate collectibles for each type
        foreach (GameObject prefab in collectiblePrefabs)
        {
            int count = collectiblesPerType;
            if (remainingCollectibles > 0)
            {
                count++;
                remainingCollectibles--;
            }

            for (int i = 0; i < count; i++)
            {
                Vector3 randomPosition = GetRandomPosition();
                Instantiate(prefab, randomPosition, Quaternion.identity);
            }
        }
    }


    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = Vector3.zero;
        bool foundEmptySpace = false;
        int attempts = 0;
        const int maxAttempts = 100;

        while (!foundEmptySpace && attempts < maxAttempts)
        {
            randomPosition = new Vector3(
                Random.Range(minBounds.x, maxBounds.x),
                Random.Range(minBounds.y, maxBounds.y),
                Random.Range(minBounds.z, maxBounds.z)
            );

            // Perform a sphere cast to check for obstacles
            Collider[] colliders = Physics.OverlapSphere(randomPosition, 0.5f, obstacleLayer);
            if (colliders.Length == 0)
            {
                foundEmptySpace = true;
            }

            attempts++;
        }

        if (!foundEmptySpace)
        {
            Debug.LogWarning("Failed to find an empty space for collectible spawn.");
        }

        return randomPosition;
    }

    void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
