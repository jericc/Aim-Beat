using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public float minimumDistance = 2.0f; // Minimum distance between targets
    public int maxAttempts = 10; // Maximum attempts to find a free spot
    private List<GameObject> targets = new List<GameObject>();

    void SpawnTarget()
    {
        bool positionFound = false;
        Vector3 spawnPosition = Vector3.zero;
        int attempts = 0;

        while (!positionFound && attempts < maxAttempts)
        {
            spawnPosition = TargetBounds.Instance.GetRandomPosition();
            positionFound = true;
            foreach (GameObject existingTarget in targets)
            {
                if (Vector3.Distance(spawnPosition, existingTarget.transform.position) < minimumDistance)
                {
                    positionFound = false;
                    break;
                }
            }
            attempts++;
        }

        if (positionFound)
        {
            GameObject newTarget = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
            targets.Add(newTarget);
        }
        else
        {
            Debug.Log("Failed to find a suitable position for a new target");
        }
    }
}
