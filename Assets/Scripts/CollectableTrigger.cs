using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            other.gameObject.transform.parent = PlayerGameController.instance.parent;
            PlayerGameController.instance.StackList.Add(other.gameObject);
            other.gameObject.tag = "Collected";
            PlayerGameController.instance.StackList[PlayerGameController.instance.StackList.Count - 1].AddComponent<CollectableTrigger>();
        }
    }
}
