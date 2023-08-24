using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
    [SerializeField] ParticleSystem crashVFX;
    [SerializeField] GameObject colliderObj;
    private void OnTriggerEnter(Collider other) {
        print("Ãæµ¹--" + other.gameObject.name);
        StartCrashSequence();
    }

    private void StartCrashSequence() {
        crashVFX.Play();
        colliderObj.SetActive(false);
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadScene", 1f);

    }

    void ReloadScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }
}
