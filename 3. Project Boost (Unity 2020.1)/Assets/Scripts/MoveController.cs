using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    private float vertical = 0f;
    private float horizontal = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            vertical = Input.GetAxis("Vertical");
        }else{
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Pressed SPACE - Thrusting");
            }
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
                Debug.Log("Rotating Left");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("Rotating Right");
            }
        }
    }
}
