using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameController : MonoBehaviour
{
    public static PlayerGameController instance;

    public float moveSpeed;

    public bool isStop = false, start = false;

    public Animator playerAnim;

    public List<GameObject> StackList = new List<GameObject>();

    public Transform parent;


    private void Awake() => instance = this;
    void Start()
    {
        InvokeRepeating("StackListUpdate", .05f, .05f);
    }

    void Update()
    {
        if (!isStop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                start = true;
            }
            if (start)
            {
                playerAnim.SetBool("isRunning", true);
                transform.parent.transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            other.transform.parent = parent;
            StackList.Add(other.gameObject);
            other.tag = "Collected";
            StackList[StackList.Count - 1].gameObject.AddComponent<CollectableTrigger>();
        }
    }

    void StackListUpdate()
    {
        if (StackList.Count > 0)
        {
            for (int i = 0; i < StackList.Count; i++)
            {
                if (i == 0)
                {
                    StackList[i].gameObject.GetComponent<SmoothDamp>().SetLeadTransform(transform);
                    StackList[i].gameObject.transform.position = transform.position + new Vector3(0, 0, 1f);
                    StackList[i].gameObject.transform.position = new Vector3(StackList[i].gameObject.transform.position.x,
                                                                             StackList[i].gameObject.transform.position.y + 0.478f,
                                                                             transform.position.z + 1f);
                }
                else
                {
                    StackList[i].gameObject.GetComponent<SmoothDamp>().SetLeadTransform(StackList[i - 1].transform);
                    StackList[i].gameObject.transform.position = new Vector3(StackList[i].gameObject.transform.position.x,
                                                                             StackList[i].gameObject.transform.position.y,
                                                                             StackList[i - 1].transform.position.z + 1f);

                }
            }
        }
    }
}
