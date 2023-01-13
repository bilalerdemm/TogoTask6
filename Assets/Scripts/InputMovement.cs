using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputMovement : MonoBehaviour, IDragHandler
{
    public Transform character;
    public GameObject myPlayer;
    public static InputMovement instance;


    private bool start = false;
    public float speed = 5.0f;

    private void Awake() => instance = this;

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 pos = character.position;
        pos.x = Mathf.Clamp(pos.x + (eventData.delta.x / 100), -4, 4);
        character.position = pos;


        /*
        Quaternion rot = child.rotation;
        rot.y = Mathf.Clamp(rot.y + (eventData.delta.x / 500), -2f, 2f);
        child.rotation = rot;
        */
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = true;
        }
        if (start == true)
        {
            //playerAnim.SetBool("isRunning", true);
            myPlayer.gameObject.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}