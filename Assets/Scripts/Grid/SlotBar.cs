using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBar : MonoBehaviour
{
    [SerializeField] public GameObject Slot1;
    [SerializeField] public GameObject Slot2;
    [SerializeField] public GameObject Slot3;
    [SerializeField] public GameObject Slot4;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) OnClickedSlot1();
        if (Input.GetKeyDown(KeyCode.Alpha2)) OnClickedSlot2();
        if (Input.GetKeyDown(KeyCode.Alpha3)) OnClickedSlot3();
        if (Input.GetKeyDown(KeyCode.Alpha4)) OnClickedSlot4();
    }

    public void OnClickedSlot1()
    {
        LineManager lm = LineManager.GetInstance();
        lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetMaterials()[0];
    }

    public void OnClickedSlot2()
    {
        LineManager lm = LineManager.GetInstance();
        lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetMaterials()[1];
    }

    public void OnClickedSlot3()
    {
        LineManager lm = LineManager.GetInstance();
        lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetMaterials()[2];
    }

    public void OnClickedSlot4()
    {
        LineManager lm = LineManager.GetInstance();
        lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetMaterials()[3];
    }
}
