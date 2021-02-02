using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float verticalInput;

    private float horizontalInput;

    public float speed = 2000.0f;

    public GameObject bombPref;

    [SerializeField] private int forceSpeed;

    public Transform target;

    private Rigidbody rb;

    private float smooth = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //bombPref = GameObject.Find("Capsule");
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * smooth);
        
        rb.AddForce(Vector3.forward * verticalInput * speed * Time.deltaTime);
        rb.AddForce(Vector3.right * horizontalInput * speed * Time.deltaTime);
        bombPref = GameObject.FindWithTag("Bomb");
        if (bombPref != null)
        {
            Debug.Log("Bomb appear!" + bombPref.GetType());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enery Collider");
        }
    }
}
