using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenTool : MonoBehaviour
{
    [Header("PenCanvas")]
    [SerializeField] private PenCanvas PenCanvas;

    [Header("Dots")]
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] Transform dotParent;

    [Header("Lines")]
    [SerializeField] Transform lineParent;
    [SerializeField] private GameObject linePrefab;
    private LineController currentLine;

    private void Start()
    {
        PenCanvas.OnPenCanvasLeftClickEvent += AddDot;
        PenCanvas.OnPenCanvasRightClickEvent += EndCurrentLine;
    }

    private void EndCurrentLine()
    {
        if(currentLine != null)
        {
            currentLine = null;
        }
    }

    private void AddDot()
    {
        if (currentLine == null)
        {
            currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineController>();
        }

        DotContoller dot = Instantiate(dotPrefab, GetMousePosition(), Quaternion.identity, dotParent).GetComponent<DotContoller>();
        dot.OnDragEvent += MoveDot;
        dot.OnRightClickEvent += RemoveDot;
        dot.OnLeftClickEvent += SetCurrentLine;
        currentLine.AddPoint(dot);
    }

    private void SetCurrentLine(DotContoller obj)
    {
        EndCurrentLine();
    }

    private void RemoveDot(DotContoller dot)
    {
        LineController line = dot.line;
        line.SplitPointsAtIndex(dot.index, out List<DotContoller> before, out List<DotContoller> after);

        Destroy(line.gameObject);
        Destroy(dot.gameObject);

        LineController beforeLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineController>();
        for(int i = 0; i < before.Count; i++)
        {
            beforeLine.AddPoint(before[i]);
        }

        LineController afterLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineController>();
        for (int i = 0; i < after.Count; i++)
        {
            afterLine.AddPoint(after[i]);
        }
    }

    private void MoveDot(DotContoller dot)
    {
        dot.transform.position = GetMousePosition();
    }

    private Vector3 GetMousePosition()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;

        return worldMousePosition;
    }
}
