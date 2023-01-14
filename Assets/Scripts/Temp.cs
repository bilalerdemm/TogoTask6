using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    public float moveSpeed = 5f;
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }
}
