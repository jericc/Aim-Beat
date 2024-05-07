using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Target : MonoBehaviour
{
    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    public void Hit()
    {
        // Notify SpawnManager about the hit
        spawnManager.TargetHit();
        transform.position = TargetBounds.Instance.GetRandomPosition();
        Debug.Log("SpawnManager notified of target hit.");
    }
}

