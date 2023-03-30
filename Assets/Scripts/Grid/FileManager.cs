using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class FileManager : MonoBehaviour
{
    [SerializeField] private GameObject LinePrefab;
    [SerializeField] private List<Material> Material_Slots = new List<Material>();

    public InputField fileNameInputField;

    public void Save()
    {
        string fileName = fileNameInputField.text;
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

        string jsonString = JsonUtility.ToJson(levelData, true);
        Debug.Log(jsonString);
        File.WriteAllText(filePath, jsonString);
    }

    public void Load()
    {
#if UNITY_EDITOR

        string filePath = UnityEditor.EditorUtility.OpenFilePanel("Overwrite with json", "", "json");
#endif

        if (File.Exists(filePath) && LinePrefab)
        {
            string jsonString = File.ReadAllText(filePath);
            LevelData data = JsonUtility.FromJson<LevelData>(jsonString);
            if (data.Level_Lines.Count == 0) return;

            for (int i = 0; i < data.Level_Lines.Count; i++)
            {
                GameObject line = Instantiate(LinePrefab);
                line.GetComponent<LineRenderer>().positionCount = 2;
                line.GetComponent<LineRenderer>().SetPosition(0, data.Level_StartPos[i]);
                line.GetComponent<LineRenderer>().SetPosition(1, data.Level_EndPos[i]);
                for(int j = 0; j < Material_Slots.Count; j++)
                {
                    if(data.Level_Mats[i] == Material_Slots[j].name + " (Instance)")
                    {
                        line.GetComponent<LineRenderer>().material = Material_Slots[j];
                    }
                }
                Debug.Log("Line!");
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
    public List<Vector3> Level_StartPos = new List<Vector3>();
    public List<Vector3> Level_EndPos = new List<Vector3>();
    public List<string> Level_Mats = new List<string>();
}