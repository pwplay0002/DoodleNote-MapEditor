using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Point : MonoBehaviour
{
    public static bool pressed;
    void OnMouseDown()
    {
        if (!SlotBar.isCurrentLine) return;
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            pressed = true;
            LineManager.StartLine(this.transform.position);
        }
    }
    void OnMouseEnter()
    {
        if (pressed)
        {
            LineManager.UpdateLine(this.transform.position);
        }
        this.GetComponent<SpriteRenderer>().color = Color.black;
    }
    void OnMouseUp()
    {
        if (pressed)
        {
            LineManager.FinishLine(this.transform.position);
            pressed = false;
        }
    }

    private void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().color = Color.gray;
    }
}
