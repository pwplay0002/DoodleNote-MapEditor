using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Line _linePrefab;
    private Stack<Line> Lines = new Stack<Line>();
    public const float RESOLUTION = .1f;

    private Line _currentLine;
    private Vector2 mousePos;
    private bool isHorizontal = true;
    void Start()
    {
        _cam = Camera.main;
        mousePos = new Vector2(0.0f, 0.0f);
    }


    void Update()
    {
        Vector2 curMousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        if (isHorizontal) mousePos.x = curMousePos.x;
        else mousePos.y = curMousePos.y;

        if (Input.GetMouseButtonDown(0))
        {
            if(isHorizontal){ mousePos.y = curMousePos.y; }
            else{ mousePos.x = curMousePos.x; }
            _currentLine = Instantiate(_linePrefab, curMousePos, Quaternion.identity);
            Lines.Push(_currentLine);
        }

        if (Input.GetMouseButton(0)){ _currentLine.SetPosition(mousePos); }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
        {
            if (Lines.Count <= 0) return;
            Destroy(Lines.Peek().gameObject);
            Lines.Pop();

        }

        // horizontal vertical
        if (Input.GetKeyDown(KeyCode.Q)) isHorizontal = !isHorizontal;
    }
}