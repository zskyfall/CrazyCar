using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10;
    private float leftBound = -15;

    private RunnerController characterControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        characterControllerScript = GameObject.Find("Character").GetComponent<RunnerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacel"))
        {
            Destroy(gameObject);
        }
    }
}
