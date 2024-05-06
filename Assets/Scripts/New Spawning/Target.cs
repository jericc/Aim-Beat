using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void Hit()
    {
        transform.position = TargetBounds.Instance.GetRandomPosition();
        Debug.Log("Hit");
    }

    void Awake()
    {
        transform.position = TargetBounds.Instance.GetRandomPosition();
    }
}
