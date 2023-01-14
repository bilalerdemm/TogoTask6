using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalWall : MonoBehaviour
{
    public bool isPlayerHit = false;
    public static FinalWall instance;

    private void Awake() => instance = this;

    private void Update()
    {
        if (Finish.instance.finalList.Count > 0)
        {
            transform.position = Finish.instance.finalList[Finish.instance.finalList.Count - 1].gameObject.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Finale player carpti");
            isPlayerHit = true;
            PlayerGameController.instance.isStop = true;
            PlayerGameController.instance.start = false;

            //other.gameObject.transform.parent = transform;

            PlayerGameController.instance.playerAnim.SetBool("isRunning", false);
            PlayerGameController.instance.playerAnim.SetBool("isWin", true);
        }
    }
}
