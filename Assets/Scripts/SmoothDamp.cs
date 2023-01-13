using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDamp : MonoBehaviour
{
    public Transform currentLeadTransform;
    private float currentVel = 0.0f, smoothTime = 0.1f;

    private void Update()
    {
        if (currentLeadTransform == null)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, currentLeadTransform.position.x,
            ref currentVel, smoothTime), transform.position.y, transform.position.z);
        }
    }
    public void SetLeadTransform(Transform leadTransform)
    {
        currentLeadTransform = leadTransform;
    }
}
