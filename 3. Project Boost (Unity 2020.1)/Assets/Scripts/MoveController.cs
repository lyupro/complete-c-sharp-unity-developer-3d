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
    private AudioSource _as_Fly;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _as_Fly = GetComponent<AudioSource>();
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
            if(!_as_Fly.isPlaying){
                _as_Fly.Play();
            }
        }else{
            if(_as_Fly.isPlaying){
                _as_Fly.Stop();
            }
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
            // Freezing rotation so we can manually rotate - FIXED BUG with in contact with other objects
            _rb.freezeRotation = true;
            // '-horizontal' due to invert A & D keys
            transform.Rotate(new Vector3(0, 0, -horizontal * speedZ * Time.fixedDeltaTime));
            // Unfreezing rotation so the phycisc system can take over
            _rb.freezeRotation = false;
        }
    }
}
