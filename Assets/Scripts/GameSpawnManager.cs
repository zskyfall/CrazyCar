using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameSpawnManager : MonoBehaviour
{
    public GameObject obstacelPrefab;
    public GameObject bombPrefab;
    public GameObject roadPrefab;
    private RunnerController _characterControllerScript;

    private float startDelay = 2;
    private float repeatRate = 2;
    
    private Vector3 spawnPos = new Vector3(25, 0, 0);    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacel", startDelay, repeatRate);
        InvokeRepeating("SpawnBomb", startDelay, repeatRate);
        InvokeRepeating("SpawnRoad", startDelay, repeatRate);
        _characterControllerScript = GameObject.Find("Character").GetComponent<RunnerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnObstacel()
    {
        if (_characterControllerScript.gameOver == false)
        {
            Instantiate(obstacelPrefab, spawnPos, obstacelPrefab.transform.rotation);
        }
    }

    private void SpawnBomb()
    {
        if (_characterControllerScript.gameOver == false)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(10,25), Random.Range(10, 20), 0);
            Instantiate(bombPrefab, randomSpawnPos, bombPrefab.transform.rotation);
        }
    }

    private void SpawnRoad()
    {
        if (_characterControllerScript.gameOver == false)
        {
            Vector3 roadSpawnPos = roadPrefab.transform.position;
            Instantiate(roadPrefab, roadSpawnPos, roadPrefab.transform.rotation);
        }
    }
}
