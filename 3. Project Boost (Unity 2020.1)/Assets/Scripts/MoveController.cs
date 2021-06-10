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
    private bool isRotate = false;

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
        if (Application.platform == RuntimePlatform.Android
        || Input.GetKey(KeyCode.A)
        || Input.GetKey(KeyCode.D)
        )
        {
            isRotate = true;
            horizontal = Input.GetAxis("Horizontal");
        }else
        {
            isRotate = false;
        }
    }

    void FixedUpdate() 
    {
        if(isFly)
        {
            _rb.AddRelativeForce(Vector3.up * speedY * Time.fixedDeltaTime);
        }

        if(isRotate)
        {
            // '-horizontal' due to invert A & D keys
            transform.Rotate(new Vector3(0, 0, -horizontal * speedZ * Time.fixedDeltaTime));
        }
    }
}
