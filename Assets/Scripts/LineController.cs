using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    private List<DotContoller> dots;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;

        dots = new List<DotContoller>();
    }

    public void AddPoint(DotContoller dot)
    {
        dot.index = dots.Count;
        dot.SetLine(this);

        lr.positionCount++;
        dots.Add(dot);
    }

    public void SplitPointsAtIndex(int index, out List<DotContoller> beforeDots, out List<DotContoller> afterDots)
    {
        List<DotContoller> before = new List<DotContoller>();
        List<DotContoller> after = new List<DotContoller>();

        int i = 0;
        for(; i < index; i++)
        {
            before.Add(dots[i]);
        }
        i++;
        for(; i < dots.Count; i++)
        {
            after.Add(dots[i]);
        }
        beforeDots = before;
        afterDots = after;
    }

    private void LateUpdate()
    {
        if(dots.Count >= 2)
        {
            for(int i = 0; i < dots.Count; i++)
            {
                lr.SetPosition(i, dots[i].transform.position);
            }
        }
    }
}
