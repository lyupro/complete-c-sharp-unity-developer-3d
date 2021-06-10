using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speedY = 1000f;
    [SerializeField] private float speedZ = 100f;

    private float vertical = 0f;
    private float horizontal = 0f;

    private bool isFly = false;

    private Rigidbody _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Application.platform == RuntimePlatform.Android
        || Input.GetKey(KeyCode.Space))
        {
            isFly = true;
        }else{
            isFly = false;
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(speedZ);
        }else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-speedZ);
        }
    }

    void FixedUpdate() 
    {
        if(isFly)
        {
            _rb.AddRelativeForce(Vector3.up * speedY * Time.fixedDeltaTime);
        }
    }

    void ApplyRotation(float rotationSpeed)
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
