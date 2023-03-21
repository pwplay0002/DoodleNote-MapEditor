using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public static bool pressed;
    void OnMouseDown()
    {
        pressed = true;
        LineManager.StartLine(this.transform.position);
    }
    void OnMouseEnter()
    {
        if (pressed)
        {
            LineManager.UpdateLine(this.transform.position);
        }
    }
    void OnMouseUp()
    {
        if (pressed)
        {
            LineManager.FinishLine(this.transform.position);
            pressed = false;
        }
    }
}
