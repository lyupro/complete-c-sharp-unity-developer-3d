using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

public class CollisionHandler : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    [SerializeField] float levelLoadDelay = 2f;
    // [SerializeField] AudioClip soundSuccess;
    // [SerializeField] AudioClip soundCrash;
    [SerializeField] SerializableDictionary<string, AudioClip> audioDict;
    [SerializeField] List<ParticleSystem> particlesList;


    // CACHE - e.g. references for readability or speed
    AudioSource m_AudioSource;


    // STATE - private instance (member) variables
    bool isTransitioning = false;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        // Prevent to StartSequence() again
        if(isTransitioning) return;

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                // StartSequence("LoadNextLevel", soundSuccess);
                StartSequence("LoadNextLevel", audioDict["Sound Success"], particlesList[0]);
                Debug.Log("Congrats, yo, you finished!");
                break;
            case "Fuel":
                Debug.Log("You picked up fuel");
                break;
            default:
                // StartSequence("ReloadLevel", soundCrash);
                StartSequence("ReloadLevel", audioDict["Sound Crash"], particlesList[1]);
                Debug.Log("Sorry, you blew up!");
                break;
        }
    }

    void StartSequence(string sequenceName, AudioClip sfx, ParticleSystem vfx)
    {
        isTransitioning = true;

        // TO-DO: Add Particle Effect upon success & crash

        if (m_AudioSource.isPlaying)
        {
            m_AudioSource.Stop();
        }
        m_AudioSource.PlayOneShot(sfx);

        if(vfx.isPlaying){
            vfx.Stop();
        }
        vfx.Play();

        GetComponent<MoveController>().enabled = false;
        Invoke(sequenceName, levelLoadDelay);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
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
