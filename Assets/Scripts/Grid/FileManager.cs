using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class FileManager : MonoBehaviour
{
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
        //string fileName = fileNameInputField.text;
        //string filePath = EditorUtility.OpenFilePanel("Overwrite with json", "", "json");

        //if (File.Exists(filePath))
        //{
        //    string jsonString = File.ReadAllText(filePath);

        //}
        //else
        //{
        //    Debug.Log("No file");
        //}
    }
}

public class LevelData
{
    public List<LineRenderer> Level_Lines = new List<LineRenderer>();
    public List<Vector3> Level_StartPos = new List<Vector3>();
    public List<Vector3> Level_EndPos = new List<Vector3>();
    public List<string> Level_Mats = new List<string>();
}