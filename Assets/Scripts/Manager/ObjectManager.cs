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
            switch (SlotBar.GetCurrentObjectSlot())
            {
                case 0:
                    {
                        if (objects.Count >= 1)
                        {
                            if (SlotBar.isClickedObject == true)
                            {
                                currentObj = Instantiate(objects[0], mousePos, Quaternion.identity);
                                SlotBar.isClickedObject = false;
                            }
                            else
                            {
                                if (currentObj != null)
                                    OnMouseMove(currentObj);
                            }
                        }
                    }; break;
                case 1:
                    {
                        if (objects.Count >= 2)
                        {
                            if (SlotBar.isClickedObject == true)
                            {
                                currentObj = Instantiate(objects[1], mousePos, Quaternion.identity);
                                SlotBar.isClickedObject = false;
                            }
                            else
                            {
                                if (currentObj != null)
                                    OnMouseMove(currentObj);
                            }
                        }
                    }; break;
                case 2:
                    {
                        if (objects.Count >= 3)
                        {
                            if (SlotBar.isClickedObject == true)
                            {
                                currentObj = Instantiate(objects[2], mousePos, Quaternion.identity);
                                SlotBar.isClickedObject = false;
                            }
                            else
                            {
                                if (currentObj != null)
                                    OnMouseMove(currentObj);
                            }
                        }
                    }; break;
                case 3:
                    {
                        if (objects.Count >= 4)
                        {
                            if (SlotBar.isClickedObject == true)
                            {
                                currentObj = Instantiate(objects[3], mousePos, Quaternion.identity);
                                SlotBar.isClickedObject = false;
                            }
                            else
                            {
                                if (currentObj != null)
                                    OnMouseMove(currentObj);
                            }
                        }
                    }; break;
                case 4:
                    {
                        if (objects.Count >= 5)
                        {
                            if (SlotBar.isClickedObject == true)
                            {
                                currentObj = Instantiate(objects[4], mousePos, Quaternion.identity);
                                SlotBar.isClickedObject = false;
                            }
                            else
                            {
                                if (currentObj != null)
                                    OnMouseMove(currentObj);
                            }
                        }
                    }; break;
                case 5:
                    {
                        if (objects.Count >= 6)
                        {
                            if (SlotBar.isClickedObject == true)
                            {
                                currentObj = Instantiate(objects[5], mousePos, Quaternion.identity);
                                SlotBar.isClickedObject = false;
                            }
                            else
                            {
                                if (currentObj != null)
                                    OnMouseMove(currentObj);
                            }
                        }
                    }; break;
                case 6:
                    {
                        if (objects.Count >= 7)
                        {
                            if (SlotBar.isClickedObject == true)
                            {
                                currentObj = Instantiate(objects[6], mousePos, Quaternion.identity);
                                SlotBar.isClickedObject = false;
                            }
                            else
                            {
                                if (currentObj != null)
                                    OnMouseMove(currentObj);
                            }
                        }
                    }; break;
                case 7:
                    {
                        if (objects.Count >= 8)
                        {
                            if (SlotBar.isClickedObject == true)
                            {
                                currentObj = Instantiate(objects[7], mousePos, Quaternion.identity);
                                SlotBar.isClickedObject = false;
                            }
                            else
                            {
                                if (currentObj != null)
                                    OnMouseMove(currentObj);
                            }
                        }
                    }; break;
                case 8:
                    {
                        if (objects.Count >= 9)
                        {
                            if (SlotBar.isClickedObject == true)
                            {
                                currentObj = Instantiate(objects[8], mousePos, Quaternion.identity);
                                SlotBar.isClickedObject = false;
                            }
                            else
                            {
                                if (currentObj != null)
                                    OnMouseMove(currentObj);
                            }
                        }
                    }; break;
                case 9:
                    {
                        if (objects.Count >= 10)
                        {
                            if (SlotBar.isClickedObject == true)
                            {
                                currentObj = Instantiate(objects[9], mousePos, Quaternion.identity);
                                SlotBar.isClickedObject = false;
                            }
                            else
                            {
                                if (currentObj != null)
                                    OnMouseMove(currentObj);
                            }
                        }
                    }; break;
                case 10:
                    {
                        if (objects.Count >= 11)
                        {
                            if (SlotBar.isClickedObject == true)
                            {
                                currentObj = Instantiate(objects[10], mousePos, Quaternion.identity);
                                SlotBar.isClickedObject = false;
                            }
                            else
                            {
                                if (currentObj != null)
                                    OnMouseMove(currentObj);
                            }
                        }
                    }; break;
                case 11:
                    {
                        if (objects.Count >= 12)
                        {
                            if (SlotBar.isClickedObject == true)
                            {
                                currentObj = Instantiate(objects[11], mousePos, Quaternion.identity);
                                SlotBar.isClickedObject = false;
                            }
                            else
                            {
                                if (currentObj != null)
                                    OnMouseMove(currentObj);
                            }
                        }
                    }; break;
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