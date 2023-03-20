using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class LevelData
{
    public List<Line> lines = new List<Line>();
    public List<Vector3Int> poses = new List<Vector3Int>();
}
