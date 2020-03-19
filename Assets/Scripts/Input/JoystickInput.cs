using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickInput : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public float KnobMovementRadius = 3f;

    public RectTransform Knob = null;

    public Vector3 MoveDirection { get; protected set; }

    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = (eventData.position - rectTransform.sizeDelta / 2f) / rectTransform.sizeDelta;//new Vector2((eventData.position.x - rectTransform.sizeDelta.x / 2f) / rectTransform.sizeDelta.x,
        //                                (eventData.position.y - rectTransform.sizeDelta.y / 2f) / rectTransform.sizeDelta.y);

        direction = Vector2.ClampMagnitude(direction, 1f);

        Knob.anchoredPosition = direction * KnobMovementRadius;

        MoveDirection = new Vector3(direction.x, 0f, direction.y);

        //Debug.Log($"Direction: {direction}");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Knob.anchoredPosition = Vector3.zero;

        MoveDirection = Vector2.zero;
    }
}
