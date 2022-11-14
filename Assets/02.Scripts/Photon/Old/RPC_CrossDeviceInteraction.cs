using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RPC_CrossDeviceInteraction : MonoBehaviour
{
    public static UnityEvent event_gazeTouch, event_touchGaze;
    private string[] returnable = new string[4];

    void Start()
    {
        if (event_gazeTouch == null)
            event_gazeTouch = new UnityEvent();
        if (event_touchGaze == null)
            event_touchGaze = new UnityEvent();
    }

    private string[] GetReportGazeTouch() // csv에 기록할 내용을 스트링형 배열로 가공
    {
        returnable[0] = "N/A";
        returnable[1] = "GazeTouch";
        returnable[2] = RPC_EyegazeGlasses.gazeOnObjGlasses;
        returnable[3] = RPC_EyegazeGlasses.gazeOnObjGlasses;
        return returnable;
    }

    private string[] GetReportTouchGaze() // csv에 기록할 내용을 스트링형 배열로 가공
    {
        returnable[0] = "N/A";
        returnable[1] = "TouchGaze";
        returnable[2] = RPC_ButtonPhone.onPointerUpButtonPhone;
        returnable[3] = RPC_EyegazeGlasses.gazeOnObjGlasses;
        return returnable;
    }

    /*
    [PunRPC]
    void RPC_gazeTouch()
    {
        // 로그에 기록
        CSVManager.AppendToReport(GetReportGazeTouch());
        event_gazeTouch.Invoke();
    }

    [PunRPC]
    void RPC_touchGaze()
    {
        // 로그에 기록
        CSVManager.AppendToReport(GetReportTouchGaze());
        event_touchGaze.Invoke();
    }
    */
}
