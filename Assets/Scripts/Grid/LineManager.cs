using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LineManager : MonoBehaviour
{
    public static LineManager instance;

    [SerializeField] List<Material> mats;
    [SerializeField] GameObject linePrefab;
    LineRenderer currentLine;
    private static Stack<LineRenderer> lines = new Stack<LineRenderer>();
    private static int matIndex = 0;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        linePrefab.GetComponent<LineRenderer>().material = mats[matIndex];
    }
    public static void StartLine(Vector3 position)
    {
        GameObject line = GameObject.Instantiate(instance.linePrefab, Vector3.zero, Quaternion.identity);
        instance.currentLine = line.GetComponent<LineRenderer>();
        instance.currentLine.positionCount = 2;
        instance.currentLine.SetPosition(0, position);
        instance.currentLine.SetPosition(1, position);
        lines.Push(instance.currentLine);
    }
    public static void UpdateLine(Vector3 position)
    {
        instance.currentLine.SetPosition(1, position);
    }
    public static void FinishLine(Vector3 position)
    {
        instance.currentLine = null;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
        {
            if (lines.Count <= 0) return;
            Destroy(lines.Peek().gameObject);
            lines.Pop();
        }
    }

    public GameObject GetLinePrefab(){ return linePrefab; }
    public List<Material> GetMaterials(){ return mats; }
    static public LineManager GetInstance() { return instance; }
    static public Stack<LineRenderer> GetLines() { return lines; }
}
