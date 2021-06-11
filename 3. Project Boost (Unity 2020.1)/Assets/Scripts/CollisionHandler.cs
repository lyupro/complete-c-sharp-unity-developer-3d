using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartSequence("LoadNextLevel");
                Debug.Log("Congrats, yo, you finished!");
                break;
            case "Fuel":
                Debug.Log("You picked up fuel");
                break;
            default:
                StartSequence("ReloadLevel");
                Debug.Log("Sorry, you blew up!");
                break;
        }
    }

    void StartSequence(string sequenceName)
    {
        // TO-DO: Add SFX upon crash
        // TO-DO: Add Particle Effect upon crash
        GetComponent<MoveController>().enabled = false;
        Invoke(sequenceName, levelLoadDelay);
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        // SceneManager.LoadScene(0);

        // Analogue, but more professional
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
