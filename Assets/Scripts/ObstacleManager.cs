using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleManager : MonoBehaviour
{
    public Transform stackPoint;
    public TextMeshProUGUI gateCounterText;
    public int gateCounter;
    public GameObject counterCube;
    public GameObject poffParticle;
    private void Update()
    {
        if (PlayerGameController.instance.StackList.Count > 1)
        {
            poffParticle.transform.position = PlayerGameController.instance.StackList[PlayerGameController.instance.StackList.Count - 1].gameObject.transform.position + new Vector3 (0,1,0);
        }
    }
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
            if (PlayerGameController.instance.StackList.Count > 1)
            {
                poffParticle.SetActive(true);
            }
            poffParticle.GetComponent<ParticleSystem>().Play();
            Debug.Log("Collected trigger oldu");
            PlayerGameController.instance.StackList.Remove(other.gameObject);
            Destroy(other.gameObject.GetComponent<SmoothDamp>());
            other.gameObject.transform.parent = transform;
            other.gameObject.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            other.gameObject.transform.position = stackPoint.position;

            gateCounter++;
            counterCube.SetActive(true);
            gateCounterText.text = gateCounter.ToString();
        }

    }
}
