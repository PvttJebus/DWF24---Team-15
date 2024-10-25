using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnManager : MonoBehaviour
{
    // Prefabs for different sizes/types of space junk
    public GameObject spawnPrefabSM;  // Small
    public GameObject spawnPrefabM;   // Medium
    public GameObject spawnPrefabLrg; // Large
    public GameObject spawnPrefabLeg; // Legendary
    public GameObject spawnPreFabGoodAlien;
    public GameObject spawnPreFabBadAlien;
    public GameObject spawnPreFabNegative;
    public GameObject spawnPreFabPositive;

    // Spawn weights for each prefab
    [Header("Spawn Weights")]
    [Tooltip("Higher weight means higher chance to spawn.")]
    public int weightSM = 50; // Small Junk weight
    public int weightM = 30;  // Medium Junk weight
    public int weightPos = 30;  // Medium Junk weight
    public int weightNeg = 30;  // Medium Junk weight
    public int weightLrg = 15; // Large Junk weight
    public int weightLeg = 5;  // Legendary Junk weight
    public int weightGood = 5;  // Legendary Junk weight
    public int weightBad = 5;  // Legendary Junk weight

    // Arrays of sprites for each junk type
    [Header("Junk Sprites")]
    [Tooltip("Sprites for Small Junk")]
    public Sprite[] smallSprites;
    [Tooltip("Sprites for Medium Junk")]
    public Sprite[] mediumSprites;
    [Tooltip("Sprites for Large Junk")]
    public Sprite[] largeSprites;
    [Tooltip("Sprites for Legendary Junk")]
    public Sprite[] legendarySprites;
    [Tooltip("Sprites for Positive")]
    public Sprite[] positiveSprites;
    [Tooltip("Sprites for Negative")]
    public Sprite[] negativeSprites;
    [Tooltip("Sprites for Good Alien")]
    public Sprite[] goodAlienSprites;
    [Tooltip("Sprites for Bad Alien")]
    public Sprite[] badAlienSprites;

    // Array to hold all spawn points tagged as "spawnpoints"
    public GameObject[] spawnPoints;

    // Array of prefabs to choose from
    private GameObject[] junkPrefabs;

    // Corresponding weights array
    private int[] junkWeights;

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

    public Junk_Bin jb;
    public float currentTimer;
    public float lastTimer;

    void Start()
    {
        lastTimer = jb.timer;
        // Find all game objects tagged as "spawnpoints" in the scene
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnpoints");

        // Initialize the junkPrefabs array with the different prefabs
        junkPrefabs = new GameObject[] { spawnPrefabSM, spawnPrefabM, spawnPrefabLrg, spawnPrefabLeg, spawnPreFabGoodAlien,spawnPreFabBadAlien, spawnPreFabNegative, spawnPreFabPositive};

        // Initialize the junkWeights array corresponding to each prefab
        junkWeights = new int[] { weightSM, weightM, weightLrg, weightLeg, weightGood, weightBad, weightPos, weightNeg };

        // Get the layer index for "Junk"
        junkLayer = LayerMask.NameToLayer(junkLayerName);
        if (junkLayer == -1)
        {
            Debug.LogError("Layer 'Junk' not found. Please ensure a layer named 'Junk' exists.");
        }
    }

    void Update()
    {
        currentTimer = jb.timer;
        // Check if the 'S' key is pressed
        if (currentTimer != lastTimer)
        {
            SpawnJunk();
            lastTimer = currentTimer;
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

        // Choose a random junk prefab based on spawn weights
        GameObject selectedPrefab = GetRandomPrefabBasedOnWeight();

        if (selectedPrefab == null)
        {
            Debug.LogError("Failed to select a prefab based on weights.");
            return;
        }

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

        // Assign a random sprite to the spawned junk
        AssignRandomSprite(selectedPrefab, spawnedJunk);
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

    // Method to select a prefab based on spawn weights
    GameObject GetRandomPrefabBasedOnWeight()
    {
        int totalWeight = 0;
        foreach (int weight in junkWeights)
        {
            totalWeight += weight;
        }

        int randomValue = Random.Range(0, totalWeight);
        int cumulativeWeight = 0;

        for (int i = 0; i < junkPrefabs.Length; i++)
        {
            cumulativeWeight += junkWeights[i];
            if (randomValue < cumulativeWeight)
            {
                return junkPrefabs[i];
            }
        }

        return null; // Should never reach here if weights are properly set
    }

    // Method to assign a random sprite to the spawned junk based on its prefab type
    void AssignRandomSprite(GameObject prefab, GameObject spawnedJunk)
    {
        Sprite[] spriteArray = null;

        if (prefab == spawnPrefabSM)
        {
            spriteArray = smallSprites;
        }
        else if (prefab == spawnPrefabM)
        {
            spriteArray = mediumSprites;
        }
        else if (prefab == spawnPrefabLrg)
        {
            spriteArray = largeSprites;
        }
        else if (prefab == spawnPrefabLeg)
        {
            spriteArray = legendarySprites;
        }
        else if (prefab == spawnPreFabGoodAlien)
        {
            spriteArray = legendarySprites;
        }
        else if (prefab == spawnPreFabBadAlien)
        {
            spriteArray = legendarySprites;
        }
        else if (prefab == spawnPreFabPositive)
        {
            spriteArray = positiveSprites;
        }
        else if (prefab == spawnPreFabNegative)
        {
            spriteArray = negativeSprites;
        }

        if (spriteArray != null && spriteArray.Length > 0)
        {
            Sprite randomSprite = spriteArray[Random.Range(0, spriteArray.Length)];
            SpriteRenderer sr = spawnedJunk.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.sprite = randomSprite;
            }
            else
            {
                Debug.LogWarning("Spawned junk does not have a SpriteRenderer component.");
            }
        }
        else
        {
            Debug.LogWarning("No sprites assigned for this junk type.");
        }
    }
}
