using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timeTillDestroy = 3f;
    private void Awake() {
        Destroy(gameObject, timeTillDestroy);
    }
}
