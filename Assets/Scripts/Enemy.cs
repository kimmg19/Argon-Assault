using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    GameObject parentGameObject;
    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] float enemyHp = 3f;

    private void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    private void AddRigidbody() {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if (enemyHp <= 0) {
            KillEnemy();
        }
    }

    private void KillEnemy() {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

    private void ProcessHit() {
        enemyHp--;
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        scoreBoard.IncreaseScore(scorePerHit);
    }
}
