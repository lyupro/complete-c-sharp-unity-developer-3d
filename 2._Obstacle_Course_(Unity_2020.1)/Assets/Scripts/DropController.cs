using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    [SerializeField] float timeToWait = 3f;

    Rigidbody _rb;
    MeshRenderer _mr;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mr = GetComponent<MeshRenderer>();

        _rb.useGravity = false;
        _mr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeToWait){
            Debug.Log("3 seconds has elapsed");
            _rb.useGravity = true;
            _mr.enabled = true;
        }
    }
}
