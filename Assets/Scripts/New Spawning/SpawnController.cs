using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Target Settings")]
    public GameObject targetPrefab; 
    [SerializeField] private float despawnTime = 5f; // Time before the target despawns 
    [SerializeField] private int maxTargets = 4; // Maximum number of targets 

    [Header("Music Settings")]
    public AudioSource gameMusic; // AudioSource component playing the game music

    [Header("Spawn Timing Settings")]
    [SerializeField, Range(30, 200)] 
    private int bpm = 100; 
    [SerializeField]
    private float initialDelay = 2f; // Initial delay period before spawning starts

    private float spawnInterval; // Interval in seconds based on BPM
    private List<GameObject> activeTargets = new List<GameObject>(); // List to keep track of active targets

    void Start()
    {
        bpm = Mathf.Clamp(bpm, 30, 200);

        spawnInterval = (60f / bpm) / 0.5f; 

        // Start the coroutine after the initial delay
        StartCoroutine(SpawnTargetsWithDelay());
    }

    IEnumerator SpawnTargetsWithDelay()
    {
        // Wait for the initial delay period before starting to spawn targets
        yield return new WaitForSeconds(initialDelay);

        // Start the music
        gameMusic.Play();

        // Begin spawning targets
        while (gameMusic.isPlaying)
        {
            // Spawn a new target if below the maximum count
            if (activeTargets.Count < maxTargets)
            {
                SpawnTarget();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnTarget()
    {
        if (targetPrefab && TargetBounds.Instance)
        {
            GameObject newTarget = Instantiate(targetPrefab, TargetBounds.Instance.GetRandomPosition(), Quaternion.identity);

            // Add the target to the list of active targets
            activeTargets.Add(newTarget);

            // Schedule the destruction of the new target 
            StartCoroutine(DespawnTargetAfterTime(newTarget, despawnTime));
        }
    }

    IEnumerator DespawnTargetAfterTime(GameObject target, float time)
    {
        yield return new WaitForSeconds(time);

        // Remove the target from the active list and destroy it
        activeTargets.Remove(target);
        Destroy(target);
    }
}

