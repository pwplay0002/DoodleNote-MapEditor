using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-------------------------------------------
 *      ObjectManager - Singleton Class
-------------------------------------------*/
public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;

    private GameObject currentObj;
    [SerializeField] List<GameObject> objects;
    public List<string> objNames = new List<string>();
    public List<Vector2> objPos = new List<Vector2>();

    private List<GameObject> obj = new List<GameObject>();
    private bool isSelected = false;
    private Vector2 mousePos;

    private void Awake()
    {
        // Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Update()
    {
        // Is Object
        if (!SlotBar.isCurrentLine)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int slotNum = (int)SlotBar.GetCurrentObjectSlot();
            if (objects.Count >= slotNum + 1)
            {
                if (SlotBar.isClickedObject == true)
                {
                    currentObj = Instantiate(objects[slotNum], mousePos, Quaternion.identity);
                    SlotBar.isClickedObject = false;
                }
                else
                {
                    if (currentObj != null)
                        OnMouseMove(currentObj);
                }
            }

            if (isSelected == true && Input.GetMouseButtonDown(0))
            {
                currentObj.transform.position = mousePos; SlotBar.isCurrentLine = true;
                objNames.Add(currentObj.gameObject.name);
                objPos.Add(currentObj.gameObject.transform.position);
                obj.Add(currentObj.gameObject);
                isSelected = false;
            }
        }
    }

    private void OnMouseMove(GameObject gameObj)
    {
        gameObj.transform.position = mousePos;
        isSelected = true;
    }

    public void ClearObjects()
    {
        for (int i = 0; i < obj.Count; i++)
        {
            Destroy(obj[i].gameObject);
        }
        obj.Clear();
        objNames.Clear();
        objPos.Clear();
    }

    public List<GameObject> GetObj() { return obj; }
    static public ObjectManager GetInstance() { return instance; }
}