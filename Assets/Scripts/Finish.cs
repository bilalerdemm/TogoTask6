using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Transform finalWay;
    public GameObject confetti, winPanel,losePanel;
    public static Finish instance;
    public List<GameObject> finalList;
    
    private void Awake() => instance = this;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collected"))
        {
            finalList.Add(other.gameObject);
            PlayerGameController.instance.StackList.Remove(other.gameObject);
            Destroy(other.gameObject.GetComponent<SmoothDamp>());
            other.gameObject.transform.parent = transform;
            other.gameObject.transform.position = finalWay.position;
            finalWay.position = new Vector3(finalWay.transform.position.x, finalWay.transform.position.y, finalWay.transform.position.z + 1);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerGameController.instance.isStop = true;
            PlayerGameController.instance.start = false;

            other.gameObject.transform.parent = transform;
            other.gameObject.transform.position = finalWay.position;
            confetti.gameObject.transform.position = finalWay.position + new Vector3(0,2,3);

            PlayerGameController.instance.playerAnim.SetBool("isRunning", false);
            PlayerGameController.instance.playerAnim.SetBool("isWin", true);

            confetti.gameObject.SetActive(true);
            winPanel.SetActive(true);

            Destroyer();
        }
    }
    void Destroyer()
    {
        foreach (var item in finalList)
        {
            Destroy(item);
        }
        finalList.Clear();
    }
}
