using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnManager : MonoBehaviour
{
    // Prefabs for different sizes/types of space junk
    public GameObject spawnPrefabSM;  // Small
    public GameObject spawnPrefabM;   // Medium
    public GameObject spawnPrefabLrg; // Large
    public GameObject spawnPrefabLeg; // Legendary?

    // Array to hold all spawn points tagged as "spawnpoints"
    public GameObject[] spawnPoints;

    // Array of prefabs to choose from
    private GameObject[] junkPrefabs;

    // Maximum number of junk pieces allowed in the scene
    [Tooltip("Maximum number of junk pieces allowed in the scene.")]
    public int maxJunk = 10;

    // Maximum angle deviation in degrees for movement direction
    [Range(0, 90)]
    [Tooltip("Maximum angle deviation from the direct path to the screen center.")]
    public float maxAngleDeviation = 30f;

    // Layer name for Junk
    private string junkLayerName = "Junk";
    private int junkLayer;

    void Start()
    {
        // Find all game objects tagged as "spawnpoints" in the scene
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnpoints");

        // Initialize the junkPrefabs array with the different prefabs
        junkPrefabs = new GameObject[] { spawnPrefabSM, spawnPrefabM, spawnPrefabLrg, spawnPrefabLeg };

        // Get the layer index for "Junk"
        junkLayer = LayerMask.NameToLayer(junkLayerName);
        if (junkLayer == -1)
        {
            Debug.LogError("Layer 'Junk' not found. Please ensure a layer named 'Junk' exists.");
        }
    }

    void Update()
    {
        // Check if the 'S' key is pressed
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnJunk();
        }
    }

    // Method to spawn junk at a random spawn point with random speed and direction
    void SpawnJunk()
    {
        // Check if the "Junk" layer exists
        if (junkLayer == -1)
        {
            Debug.LogError("Cannot spawn junk because the 'Junk' layer does not exist.");
            return;
        }

        // Get the current number of junk pieces in the scene by counting objects in the "Junk" layer
        int currentJunkCount = CountObjectsInLayer(junkLayer);

        // Check if we have reached the maximum limit
        if (currentJunkCount >= maxJunk)
        {
            // Optionally, you can log a message or perform another action
            Debug.Log("Maximum junk limit reached. Cannot spawn more junk.");
            return;
        }

        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points found. Please tag your spawn points with 'spawnpoints'.");
            return;
        }

        // Select a random spawn point
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        GameObject selectedSpawnPoint = spawnPoints[spawnIndex];

        // Choose a random junk prefab
        int prefabIndex = Random.Range(0, junkPrefabs.Length);
        GameObject selectedPrefab = junkPrefabs[prefabIndex];

        // Instantiate the selected prefab at the spawn point's position with no rotation
        GameObject spawnedJunk = Instantiate(selectedPrefab, selectedSpawnPoint.transform.position, Quaternion.identity);

        // Assign the "Junk" layer to the spawned junk
        spawnedJunk.layer = junkLayer;

        // Assign a random speed to the spawned junk
        JunkMover mover = spawnedJunk.GetComponent<JunkMover>();
        if (mover != null)
        {
            // Assign a random speed between minSpeed and maxSpeed
            float minSpeed = 1f;
            float maxSpeed = 5f;
            float randomSpeed = Random.Range(minSpeed, maxSpeed);
            mover.speed = randomSpeed;

            // Determine movement direction toward the screen center (assumed at (0,0,0))
            Vector3 spawnPos = selectedSpawnPoint.transform.position;
            Vector3 screenCenter = Vector3.zero; // Adjust if your screen center is different
            Vector3 baseDirection = (screenCenter - spawnPos).normalized;

            // Apply a random rotation to the base direction
            float randomAngle = Random.Range(-maxAngleDeviation, maxAngleDeviation);
            Quaternion rotation = Quaternion.AngleAxis(randomAngle, Vector3.forward); // Assuming 2D (Z-axis rotation)
            Vector3 randomDirection = rotation * baseDirection;

            // Assign the randomized direction to the JunkMover
            mover.movementDirection = randomDirection;
        }
        else
        {
            Debug.LogWarning("Spawned junk prefab does not have a JunkMover script attached.");
        }
    }

    // Helper method to count the number of GameObjects on a specific layer
    int CountObjectsInLayer(int layer)
    {
        // Find all active GameObjects in the scene
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        int count = 0;
        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == layer)
            {
                count++;
            }
        }
        return count;
    }
}
