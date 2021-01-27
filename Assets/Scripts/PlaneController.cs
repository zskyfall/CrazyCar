using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    public float speed = 40;

    public float maxSpeed = 100;

    public float minSpeed = 10;
    
    private float turnSpeed = 25.0f;

    private float horizontalInput;

    private float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        //Di chuyển xe tiến lùi
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        
        //Di chuyển xe quay trái phải
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        
        //Di chuyển lên xuống
        transform.Rotate(Vector3.up, turnSpeed * verticalInput * Time.deltaTime);
    }
}
