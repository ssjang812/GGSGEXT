using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGazeTouch : MonoBehaviour
{
    //WISE DEMO 에서 만들었던것. 지금은 아마 ExperimentManager 에 들어있을텐데 모듈화해서 만들면 이렇게 될 것
    private GameObject lastTreePanel, whiteTreePanel, redTreePanel;
    //private UIController uiController;
    private RPC_CrossDeviceInteraction RPC_crossDeviceInteraction;

    void Start()
    {
        //RPC_crossDeviceInteraction = GameObject.FindGameObjectWithTag("WorldEvent").GetComponent<RPC_CrossDeviceInteraction>();
        lastTreePanel = GameObject.FindGameObjectWithTag("LastTreePanel");
        whiteTreePanel = GameObject.FindGameObjectWithTag("WhiteTreePanel");
        redTreePanel = GameObject.FindGameObjectWithTag("RedTreePanel");
        //uiController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();

        RPC_CrossDeviceInteraction.event_gazeTouch.AddListener(OpenCertainPage); // 실행순서가 저쪽 초기화보다 빠르면 null exception이 뜨더라, 동적할당을 동적할당할때 주의
    }

    private void OpenCertainPage()
    {
        if (RPC_EyegazeGlasses.gazeOnObjGlasses == "LastTreeModel")
        {
            //uiController.activeItem = 2;
            //uiController.OnDetailButtonClicked();
        }
        else if (RPC_EyegazeGlasses.gazeOnObjGlasses == "WhiteTreeModel")
        {
            //uiController.activeItem = 3;
            //uiController.OnDetailButtonClicked();
        }
        else if (RPC_EyegazeGlasses.gazeOnObjGlasses == "RedTreeModel")
        {
            //uiController.activeItem = 4;
            //uiController.OnDetailButtonClicked();
        }
    }
}
