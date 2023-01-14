using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && PlayerGameController.instance.StackList.Count == 0)
        {
            Debug.Log("Fail");
        }
        if (other.gameObject.CompareTag("Collected"))
        {
            Debug.Log("Collected trigger oldu");
        }

    }
}
