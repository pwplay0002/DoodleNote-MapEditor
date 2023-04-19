using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotBar : MonoBehaviour
{
    [SerializeField] public GameObject Line_Slot1;
    [SerializeField] public GameObject Line_Slot2;
    [SerializeField] public GameObject Line_Slot3;
    [SerializeField] public GameObject Line_Slot4;
    [SerializeField] public GameObject Line_Slot5;
    [SerializeField] public GameObject Line_Slot6;
    [SerializeField] public GameObject Line_Slot7;

    [SerializeField] public GameObject Object_Slot1;
    [SerializeField] public GameObject Object_Slot2;
    [SerializeField] public GameObject Object_Slot3;
    [SerializeField] public GameObject Object_Slot4;
    [SerializeField] public GameObject Object_Slot5;
    [SerializeField] public GameObject Object_Slot6;
    [SerializeField] public GameObject Object_Slot7;
    [SerializeField] public GameObject Object_Slot8;
    [SerializeField] public GameObject Object_Slot9;
    [SerializeField] public GameObject Object_Slot10;
    [SerializeField] public GameObject Object_Slot11;

    private bool isRoundLine = false;
    private uint currLineNum = 1;
    static public bool isClickedObject = false;
    static public bool isCurrentLine = true;
    static private uint currentObjectSlot = 0;

    static public uint GetCurrentObjectSlot() { return currentObjectSlot; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) OnClickedLineSlotR();

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // Objects
            if (Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha1)) OnClickedObjectSlot1();
            else if (Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha2)) OnClickedObjectSlot2();
            else if (Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha3)) OnClickedObjectSlot3();
            else if (Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha4)) OnClickedObjectSlot4();
            else if (Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha5)) OnClickedObjectSlot5();
            else if (Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha6)) OnClickedObjectSlot6();
            else if (Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha7)) OnClickedObjectSlot7();
            else if (Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha8)) OnClickedObjectSlot8();
            else if (Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha9)) OnClickedObjectSlot9();
            else if (Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha0)) OnClickedObjectSlot10();
            else if (Input.GetKey("`") && Input.GetKeyDown(KeyCode.Minus)) OnClickedObjectSlot11();

            // Lines
            else if (!Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha1)) OnClickedLineSlot1();
            else if (!Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha2)) OnClickedLineSlot2();
            else if (!Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha3)) OnClickedLineSlot3();
            else if (!Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha4)) OnClickedLineSlot4();
            else if (!Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha5)) OnClickedLineSlot5();
            else if (!Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha6)) OnClickedLineSlot6();
            else if (!Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha7)) OnClickedLineSlot7();
            else if (!Input.GetKey("`") && Input.GetKeyDown(KeyCode.Alpha8)) OnClickedLineSlotR();
        }
    }

    public void OnClickedLineSlot1()
    {
        currLineNum = 1;
        isCurrentLine = true;
        LineManager lm = LineManager.GetInstance();
        if (isRoundLine == true)
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetRMaterials()[0];
        else
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetMaterials()[0];
    }

    public void OnClickedLineSlot2()
    {
        currLineNum = 2;
        isCurrentLine = true;
        LineManager lm = LineManager.GetInstance();
        if (isRoundLine == true)
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetRMaterials()[1];
        else
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetMaterials()[1];
    }

    public void OnClickedLineSlot3()
    {
        currLineNum = 3;
        isCurrentLine = true;
        LineManager lm = LineManager.GetInstance();
        if (isRoundLine == true)
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetRMaterials()[2];
        else
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetMaterials()[2];
    }

    public void OnClickedLineSlot4()
    {
        currLineNum = 4;
        isCurrentLine = true;
        LineManager lm = LineManager.GetInstance();
        if (isRoundLine == true)
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetRMaterials()[3];
        else
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetMaterials()[3];
    }

    public void OnClickedLineSlot5()
    {
        currLineNum = 5;
        isCurrentLine = true;
        LineManager lm = LineManager.GetInstance();
        if (isRoundLine == true)
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetRMaterials()[4];
        else
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetMaterials()[4];
    }

    public void OnClickedLineSlot6()
    {
        currLineNum = 6;
        isCurrentLine = true;
        LineManager lm = LineManager.GetInstance();
        if (isRoundLine == true)
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetRMaterials()[5];
        else
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetMaterials()[5];
    }

    public void OnClickedLineSlot7()
    {
        currLineNum = 7;
        isCurrentLine = true;
        LineManager lm = LineManager.GetInstance();
        if (isRoundLine == true)
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetRMaterials()[6];
        else
            lm.GetLinePrefab().GetComponent<LineRenderer>().material = lm.GetMaterials()[6];
    }

    public void OnClickedLineSlotR()
    {
        isRoundLine = !isRoundLine;
        switch (currLineNum)
        {
            case 1: { OnClickedLineSlot1(); } break;
            case 2: { OnClickedLineSlot2(); } break;
            case 3: { OnClickedLineSlot3(); } break;
            case 4: { OnClickedLineSlot4(); } break;
            case 5: { OnClickedLineSlot5(); } break;
            case 6: { OnClickedLineSlot6(); } break;
            case 7: { OnClickedLineSlot7(); } break;
        }
    }

    //-------------------------------------------------------------------------------------

    public void OnClickedObjectSlot1()
    {
        currentObjectSlot = 0;
        isCurrentLine = false;
        isClickedObject = true;
    }

    public void OnClickedObjectSlot2()
    {
        currentObjectSlot = 1;
        isCurrentLine = false;
        isClickedObject = true;
    }

    public void OnClickedObjectSlot3()
    {
        currentObjectSlot = 2;
        isCurrentLine = false;
        isClickedObject = true;
    }

    public void OnClickedObjectSlot4()
    {
        currentObjectSlot = 3;
        isCurrentLine = false;
        isClickedObject = true;
    }

    public void OnClickedObjectSlot5()
    {
        currentObjectSlot = 4;
        isCurrentLine = false;
        isClickedObject = true;
    }

    public void OnClickedObjectSlot6()
    {
        currentObjectSlot = 5;
        isCurrentLine = false;
        isClickedObject = true;
    }

    public void OnClickedObjectSlot7()
    {
        currentObjectSlot = 6;
        isCurrentLine = false;
        isClickedObject = true;
    }

    public void OnClickedObjectSlot8()
    {
        currentObjectSlot = 7;
        isCurrentLine = false;
        isClickedObject = true;
    }

    public void OnClickedObjectSlot9()
    {
        currentObjectSlot = 8;
        isCurrentLine = false;
        isClickedObject = true;
    }

    public void OnClickedObjectSlot10()
    {
        currentObjectSlot = 9;
        isCurrentLine = false;
        isClickedObject = true;
    }

    public void OnClickedObjectSlot11()
    {
        currentObjectSlot = 10;
        isCurrentLine = false;
        isClickedObject = true;
    }
}