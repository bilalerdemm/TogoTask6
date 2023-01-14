using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public Transform stackPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && PlayerGameController.instance.StackList.Count == 0)
        {
            Debug.Log("Fail");
            PlayerGameController.instance.isStop = true;
            PlayerGameController.instance.start = false;
            PlayerGameController.instance.playerAnim.SetBool("isFail", true);
            Finish.instance.losePanel.SetActive(true);
        }
        if (other.gameObject.CompareTag("Collected"))
        {
            Debug.Log("Collected trigger oldu");
            PlayerGameController.instance.StackList.Remove(other.gameObject);
            Destroy(other.gameObject.GetComponent<SmoothDamp>());
            other.gameObject.transform.parent = transform;
            other.gameObject.transform.position = stackPoint.position;
        }

    }
}
