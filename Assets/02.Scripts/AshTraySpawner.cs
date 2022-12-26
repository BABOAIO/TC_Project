using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshTraySpawner : MonoBehaviour
{
    public GameObject AshPrefab;
    public float spawnRate = 1.0f;

    private Transform target;
    private float spawnTime = 0;
    private float timeAfterSpawn;


    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        //target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
