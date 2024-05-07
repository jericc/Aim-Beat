using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
     [Header("UI Elements")]
    public TextMeshProUGUI accuracyText;
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

    private int targetsSpawned = 0; // Number of targets spawned
    private int targetsHit = 0; // Number of targets hit

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

            // Increment targets spawned count
            targetsSpawned++;
            Debug.Log("Target Spawned:" + targetsSpawned);

            // Add the target to the list of active targets
            activeTargets.Add(newTarget);

            // Schedule the destruction of the new target 
            StartCoroutine(DespawnTargetAfterTime(newTarget, despawnTime));
            UpdateAccuracyUI();
        }
    }

    IEnumerator DespawnTargetAfterTime(GameObject target, float time)
    {
        yield return new WaitForSeconds(time);

        // Remove the target from the active list and destroy it
        activeTargets.Remove(target);
        Destroy(target);
        UpdateAccuracyUI();
    }

    // Method to track targets hit
    public void TargetHit()
    {
        // Increment targets hit count
        Debug.Log("TargetHit method called");
        targetsHit++;
        Debug.Log("TargtHit"+ targetsHit);
        // Log the accuracy every time a target is hit
        LogAccuracy();
    }

    // Method to calculate accuracy percentage
    public float CalculateAccuracyPercentage()
    {
        if (targetsSpawned > 0)
        {
            float accuracy = ((float)targetsHit / (float)targetsSpawned) * 100f;
            return Mathf.Min(accuracy, 100f);  // Ensure accuracy does not exceed 100%
        }
        else
        {
            return 0f; // Avoid division by zero
        }
    }


    public void LogAccuracy()
    {
        float accuracy = CalculateAccuracyPercentage();
        // Debug.Log($"Current Accuracy: {accuracy}%");
    }
    void UpdateAccuracyUI()
    {
        float accuracy = CalculateAccuracyPercentage();
        if (accuracyText != null)
            accuracyText.text = $"Accuracy: {accuracy:F2}%";
    }

    void Update()
    {
        LogAccuracy();
        // UpdateAccuracyUI();
    }
}