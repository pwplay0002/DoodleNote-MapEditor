using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LineManager : MonoBehaviour
{
    [SerializeField] List<Material> Mats;
    [SerializeField] GameObject linePrefab;
    LineRenderer currentLine;
    public static LineManager Instance;
    private static Stack<LineRenderer> Lines = new Stack<LineRenderer>();
    private static int matIndex = 0;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
    public static void StartLine(Vector3 position)
    {
        GameObject line = GameObject.Instantiate(Instance.linePrefab, Vector3.zero, Quaternion.identity);
        Instance.currentLine = line.GetComponent<LineRenderer>();
        Instance.currentLine.positionCount = 2;
        Instance.currentLine.SetPosition(0, position);
        Instance.currentLine.SetPosition(1, position);
        Lines.Push(Instance.currentLine);
    }
    public static void UpdateLine(Vector3 position)
    {
        Instance.currentLine.SetPosition(1, position);
    }
    public static void FinishLine(Vector3 position)
    {
        Instance.currentLine = null;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
        {
            if (Lines.Count <= 0) return;
            Destroy(Lines.Peek().gameObject);
            Lines.Pop();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            linePrefab.GetComponent<LineRenderer>().material = Mats[matIndex % (Mats.Count)];
            Debug.Log("Change");
            matIndex++;
        }
    }
}
