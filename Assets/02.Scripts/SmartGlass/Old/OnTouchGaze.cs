using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchGaze : MonoBehaviour
{
    // WISE DEMO에서 만들었던것, 이거용으로 싹 바꿔야함 -> 버튼에서 손땔때에 등록해서 쓰면 됨
    public GameObject treeModel1, treeModel2, treeModel3;
    private GameObject genModel;

    void Start()
    {
        RPC_CrossDeviceInteraction.event_touchGaze.AddListener(GenerateCertainObject);
    }

    private void GenerateCertainObject()
    {
        //Debug.Log("GenerateCertainObject " + RPC_EyegazeGlasses.gazeOnObjPosition);
        if (RPC_ButtonPhone.onPointerUpButtonPhone == "LastTreeButton")
        {
            genModel = treeModel1;
        }
        else if (RPC_ButtonPhone.onPointerUpButtonPhone == "WhiteTreeButton")
        {
            genModel = treeModel2;
        }
        else if (RPC_ButtonPhone.onPointerUpButtonPhone == "RedTreeButton")
        {
            genModel = treeModel3;
        }

        //Instantiate(genModel, RPC_EyegazeGlasses.gazeOnObjPosition, Quaternion.identity);
    }
}
