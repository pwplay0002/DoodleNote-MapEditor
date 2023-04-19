using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    //public static Grid Instance;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] private int width = 20;
    [SerializeField] private int height = 10;
    private List<GameObject> dots = new List<GameObject>();

    private void Awake()
    {
        Vector2 dotPos = new Vector2();

        for (float x = -20; x < width; x+=0.5f)
        {
            for (float y = -10; y < height; y+=0.5f)
            {
                dotPos.x = x;
                dotPos.y = y;
                dots.Add(Instantiate(dotPrefab, dotPos, Quaternion.identity));
            }
        }
    }
}
