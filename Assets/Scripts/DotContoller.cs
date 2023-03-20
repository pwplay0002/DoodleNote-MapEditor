using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class DotContoller : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    public LineController line;
    public int index;

    public Action<DotContoller> OnDragEvent;
    public void OnDrag(PointerEventData eventData)
    {
        OnDragEvent?.Invoke(this);
    }

    public Action<DotContoller> OnRightClickEvent;
    public Action<DotContoller> OnLeftClickEvent;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerId == -2)
        {
            OnRightClickEvent?.Invoke(this);
        }
        else if(eventData.pointerId == -1)
        {
            OnLeftClickEvent?.Invoke(this);
        }
    }

    public void SetLine(LineController line)
    {
        this.line = line;
    }
}
