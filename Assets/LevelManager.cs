using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Level[] levels; // Array of levels
    private int currentLevelIndex = 0;
    private int slimesDefeated = 0; // Track slimes defeated in the current level
    private SlimeSpawner slimeSpawner; // Reference to the SlimeSpawner

    void Start()
    {
        // Find the SlimeSpawner in the scene
        slimeSpawner = FindObjectOfType<SlimeSpawner>();

        // Start the first level and from here the other levels will be called from unity
        StartLevel(currentLevelIndex);
    }

    public void OnSlimeDefeated()
    {
        slimesDefeated++; // Increment defeated counter

        // Checks if the current level is complete then ask fro the next
        if (slimesDefeated >= levels[currentLevelIndex].slimesToDefeat)
        {
            AdvanceLevel();
        }
    }

    public void AdvanceLevel() 
    {
        slimesDefeated = 0; // Reset count for the new level
        currentLevelIndex++;

        if (currentLevelIndex < levels.Length)
        {
            Debug.Log("Level Complete! Moving to Level " + (currentLevelIndex + 1));
            // Set slimes to spawn for the new level from "count of slimes in unity"
            slimeSpawner.SetSlimesToSpawn(levels[currentLevelIndex].slimesToDefeat);
        }
        else
        {
            Debug.Log("All Levels Complete!");
            // Optionally, you can implement logic to restart or end the game
        }
    }

    // Start a level and initialize slime spawning
    private void StartLevel(int index)
    {
        currentLevelIndex = index; // Set the current level index
        slimeSpawner.SetSlimesToSpawn(levels[currentLevelIndex].slimesToDefeat); // Set the slimes to spawn
    }
}
