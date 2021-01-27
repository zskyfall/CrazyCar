using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatRoad : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatLength;
    
    private float startDelay = 1;
    private float repeatRate = 1;
    public GameObject roadPrefab;
    private RunnerController runnerController;
    
    // Start is called before the first frame update
    void Start()
    {
        runnerController = GameObject.Find("Character").GetComponent<RunnerController>();
        startPos = transform.position;
        repeatLength = GetComponent<BoxCollider>().size.y / 2;
        InvokeRepeating("SpawnRoad", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnRoad()
    {
        if (runnerController.gameOver == false)
        {
            Vector3 spawnPos = roadPrefab.transform.position;
            Instantiate(roadPrefab, spawnPos, roadPrefab.transform.rotation);
        }
    }
}
