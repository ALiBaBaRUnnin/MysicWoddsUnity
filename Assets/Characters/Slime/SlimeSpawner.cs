using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject slimePrefab; // Reference to the slime prefab
    public float spawnDelay = 2f; // Delay between spawning each slime

    private int slimesPerLevel; // Number of slimes required for the current level
    private int slimesSpawned = 0; // Track number of slimes spawned for the current level
    private int slimesDefeated = 0; // Track number of slimes defeated for the current level
    private List<GameObject> currentSlimes = new List<GameObject>(); // List to track current slimes
    private bool isSpawning = false; // Flag to control spawning

    void Start()
    {
        // Initially, we won't spawn slimes until we set the level
    }

    void Update()
    {
        // Ensure currentSlimes list is not null or empty
        if (currentSlimes != null && currentSlimes.Count > 0)
        {
            // Clean up null entries when slimes are destroyed and update defeated count
            currentSlimes.RemoveAll(slime => {
                if (slime == null)
                {
                    slimesDefeated++;
                    return true;
                }
                return false;
            });
        }

        // Check if the level is complete
        if (slimesDefeated >= slimesPerLevel)
        {
            AdvanceLevel();
        }
    }

    // This method sets the number of slimes for the current level and starts spawning
    public void SetSlimesToSpawn(int number)
    {
        slimesPerLevel = number; // Set the number of slimes to spawn
        slimesSpawned = 0; // Reset spawned count
        slimesDefeated = 0; // Reset defeated count
        currentSlimes.Clear(); // Clear any existing slimes
        StartCoroutine(SpawnSlimeWithDelay()); // Start spawning slimes
    }

    IEnumerator SpawnSlimeWithDelay()
    {
        isSpawning = true;

        // Spawn the defined number of slimes for the current level
        while (slimesSpawned < slimesPerLevel)
        {
            SpawnSlime();
            slimesSpawned++;
            yield return new WaitForSeconds(spawnDelay);
        }

        isSpawning = false; // Stop spawning when done
    }

    void SpawnSlime()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), 0);
        GameObject newSlime = Instantiate(slimePrefab, spawnPosition, Quaternion.identity);
        currentSlimes.Add(newSlime); // Add the new slime to the list
    }

    void AdvanceLevel()
    {
        // Trigger the LevelManager to advance to the next level
        FindObjectOfType<LevelManager>().AdvanceLevel();
    }
}
