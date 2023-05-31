using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControl : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public PlayerMovement Player;
    public VerticalMovement Capsule;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // При свайпе по горизонтали
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
            {
                Player.NextPlayerRowPositionRight();
            }
            else
            {
                Player.NextPlayerRowPositionLeft();
            }
        }
        // При свайпе по вертикале
        else
        {
            if (eventData.delta.y > 0)
            {
                Capsule.Jump();
            }
            else
            {
                Capsule.Slide();
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Без этого метода свайпы работать не будут
    }
}
