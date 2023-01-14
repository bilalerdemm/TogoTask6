using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputMovement : MonoBehaviour, IDragHandler
{
    public Transform character;
    public static InputMovement instance;

    private bool start = false;

    private void Awake() => instance = this;

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 pos = character.position;
        pos.x = Mathf.Clamp(pos.x + (eventData.delta.x / 100), -4, 4);
        character.position = pos;
    }
}