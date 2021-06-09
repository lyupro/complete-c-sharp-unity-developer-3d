using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
            // Debug.Log("Bumped into a wall");
            if(other.gameObject.CompareTag("Player")){
                GetComponent<MeshRenderer>().material.color = Color.red;
                gameObject.tag = "Obstacle";
            }
    }
}
