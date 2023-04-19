using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

/*-------------------------------------------
 *              FileManager
-------------------------------------------*/
public class FileManager : MonoBehaviour
{
    [SerializeField] private GameObject LinePrefab;
    [SerializeField] private List<Material> Material_Slots = new List<Material>();

    public InputField saveFileNameInputField;
    public InputField loadFileNameInputField;

    public void Save()
    {
        string fileName = saveFileNameInputField.text;
        string filePath = Application.dataPath + "/" + fileName + ".json";

        LevelData levelData = new LevelData();
        Stack<LineRenderer> stk = new Stack<LineRenderer>(LineManager.GetLines());

        while (stk.Count > 0)
        {
            levelData.Level_Lines.Add(stk.Peek());
            levelData.Level_Mats.Add(stk.Peek().material.name);
            levelData.Level_StartPos.Add(stk.Peek().GetPosition(0));
            levelData.Level_EndPos.Add(stk.Peek().GetPosition(1));
            Debug.Log(stk.Peek().GetPosition(0) + " " + stk.Peek().GetPosition(1));
            stk.Pop();
        }

        for (int i = 0; i < ObjectManager.GetInstance().objPos.Count; i++)
        {
            levelData.Level_ObjectName.Add(ObjectManager.GetInstance().objNames[i]);
            levelData.Level_ObjPos.Add(ObjectManager.GetInstance().objPos[i]);
        }

        string jsonString = JsonUtility.ToJson(levelData, true);
        Debug.Log(jsonString);
        File.WriteAllText(filePath, jsonString);
    }

    public void Load()
    {
        string fileName = loadFileNameInputField.text;
        string filePath = Application.dataPath + "/" + fileName + ".json";

        if (File.Exists(filePath) && LinePrefab)
        {
            string jsonString = File.ReadAllText(filePath);
            LevelData data = JsonUtility.FromJson<LevelData>(jsonString);
            if (data.Level_Lines.Count == 0) return;

            for (int i = 0; i < data.Level_Lines.Count; i++)
            {
                // Add Line Renderers
                GameObject line = Instantiate(LinePrefab);
                line.GetComponent<LineRenderer>().positionCount = 2;
                line.GetComponent<LineRenderer>().SetPosition(0, data.Level_StartPos[i]);
                line.GetComponent<LineRenderer>().SetPosition(1, data.Level_EndPos[i]);

                // Add Edge Colliders
                List<Vector2> colliders = new List<Vector2>();
                colliders.Add(new Vector2(line.GetComponent<LineRenderer>().GetPosition(0).x, line.GetComponent<LineRenderer>().GetPosition(0).y));
                colliders.Add(new Vector2(line.GetComponent<LineRenderer>().GetPosition(1).x, line.GetComponent<LineRenderer>().GetPosition(1).y));

                line.GetComponent<EdgeCollider2D>().points = colliders.ToArray();

                for (int j = 0; j < Material_Slots.Count; j++)
                {
                    if (data.Level_Mats[i] == Material_Slots[j].name + " (Instance)")
                    {
                        line.GetComponent<LineRenderer>().material = Material_Slots[j];
                        line.tag = Material_Slots[j].name;
                    }
                }
            }
        }
        else
        {
            Debug.Log("No file");
        }
    }
}

public class LevelData
{
    public List<LineRenderer> Level_Lines = new List<LineRenderer>();
    public List<Vector2> Level_StartPos = new List<Vector2>();
    public List<Vector2> Level_EndPos = new List<Vector2>();
    public List<string> Level_Mats = new List<string>();
    public List<string> Level_ObjectName = new List<string>();
    public List<Vector2> Level_ObjPos = new List<Vector2>();
}