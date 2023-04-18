using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-------------------------------------------
 *      DeleteManager - Singleton Class
-------------------------------------------*/
public class DeleteManager : MonoBehaviour
{
    public static DeleteManager instance;

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
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                int idx = -1;
                for(int i = 0; i < ObjectManager.GetInstance().GetObj().Count; i++)
                {
                    if(ObjectManager.GetInstance().GetObj()[i].GetInstanceID() == hit.collider.gameObject.GetInstanceID())
                    {
                        idx = i;
                        break;
                    }
                }
                if(idx != -1)
                {
                    GameObject temp = ObjectManager.GetInstance().GetObj()[idx].gameObject;
                    ObjectManager.GetInstance().GetObj().RemoveAt(idx);
                    ObjectManager.GetInstance().objNames.RemoveAt(idx);
                    ObjectManager.GetInstance().objPos.RemoveAt(idx);
                    Destroy(temp);
                    idx = -1;

                }
            }
        }
    }
    static public DeleteManager GetInstance() { return instance; }

}
