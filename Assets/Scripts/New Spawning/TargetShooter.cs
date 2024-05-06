using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] Camera cam;
    public float rayLength = 100f; 
    public Color rayColor = Color.red; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayLength))
            {
                Debug.DrawLine(ray.origin, hit.point, rayColor, 1.0f); 

                Target target = hit.collider.gameObject.GetComponent<Target>();
                if (target != null)
                {
                    target.Hit();
                    Debug.Log("Target Hit");
                }
            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayLength, rayColor, 1.0f); 
            }
        }
    }
}
