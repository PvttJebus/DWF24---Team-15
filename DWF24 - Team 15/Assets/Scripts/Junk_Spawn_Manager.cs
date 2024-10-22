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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(spawnPrefabM,Spawner.transform);
            
        }
    }
}
