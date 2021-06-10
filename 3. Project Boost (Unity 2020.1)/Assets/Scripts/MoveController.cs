using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float vertical = 0f;
    private float horizontal = 0f;

    private bool isFly = false;

    private Rigidbody _rb;

    const float speedYMultiplier = 300f;

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
        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.GetAxis("Horizontal");
        }else
        {
            if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontal = 1f;
            }else{
                horizontal = 0f;
            }
        }
    }

    void FixedUpdate() 
    {
        if(isFly)
        {
            _rb.AddRelativeForce(Vector3.up * speedYMultiplier * Time.fixedDeltaTime);
        }
    }
}
