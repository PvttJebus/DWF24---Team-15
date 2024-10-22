using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk_Spawn_Manager : MonoBehaviour
{

    public GameObject Spawner;
    public GameObject spawnPrefabSM;
    public GameObject spawnPrefabM;
    public GameObject spawnPrefabLrg;
    public GameObject spawnPrefabLeg;
    public GameObject[] spawnPoints;
    public GameObject currentpoint;
    int index;


    void Start()
    {

        spawnPoints = GameObject.FindGameObjectsWithTag("spawnpoints");
        
    }
    void Update()
    {
        index = Random.Range(0, spawnPoints.Length);
        currentpoint = spawnPoints[index];
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(spawnPrefabM, currentpoint.transform);


        }
    }
}
