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
    public GameObject[] obstacelPrefabs;
    private RunnerController _characterControllerScript;

    public float startDelay = 5;
    public float repeatRate = 3.0f;

    public float roadStartDelay = 2;
    public float roadRepeatRate = 3.0f;
    private int point = 0;
    private float baseDifficult = 1000.0f;
    
    private Vector3 spawnPos = new Vector3(25, 0, 0);    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacel", startDelay, repeatRate);
        InvokeRepeating("SpawnBomb", startDelay, repeatRate);
        InvokeRepeating("SpawnRoad", roadStartDelay, roadRepeatRate);
        _characterControllerScript = GameObject.Find("Character").GetComponent<RunnerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((_characterControllerScript != null) && (_characterControllerScript.gameOver == false))
        {
            point++;
            //Inscrease difficulty by point
            UpdateDifficulty(point);
        }
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
            Vector3 randomSpawnPos = new Vector3(Random.Range(0,25), Random.Range(15, 25), 0);
            Instantiate(bombPrefab, randomSpawnPos, bombPrefab.transform.rotation);
        }
    }

    private void SpawnObstacel(GameObject obj, Vector3 pos)
    {
        if (_characterControllerScript.gameOver == false)
        {
            Instantiate(obj, pos, obj.transform.rotation);
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

    private void UpdateDifficulty(int point)
    {
        if ((point / baseDifficult > 1) && (point % baseDifficult == 0) && repeatRate >= 1)
        {
            float diff = point / baseDifficult / 10.0f;
            repeatRate -= diff;
            
            Debug.Log("Diff: " + diff+ ".Point: " + point + ". Repeat rate: " + repeatRate);
        }
    }
}
