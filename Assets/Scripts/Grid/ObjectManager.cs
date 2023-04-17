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
        if(!SlotBar.isCurrentLine)
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
                                if(currentObj != null)
                                OnMouseMove(currentObj);
                            }
                        }
                    };break;
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
            }

            if (Input.GetMouseButtonDown(0)) { currentObj.transform.position = mousePos; SlotBar.isCurrentLine = true; }
        }
    }

    private void OnMouseMove(GameObject gameObj)
    {
        gameObj.transform.position = mousePos;
    }

    static public ObjectManager GetInstance() { return instance; }
}
