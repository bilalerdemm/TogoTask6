using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Fail");
        }
        if (other.gameObject.CompareTag("Collected"))
        {
            Debug.Log("Collected trigger oldu");
        }
        if (other.gameObject.CompareTag("Temp"))
        {
            Debug.Log("Temp trigger oldu");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Temp"))
        {
            Debug.Log("Temp collision oldu");
        }
    }
}
