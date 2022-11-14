using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RPC_GestureGlasses : MonoBehaviour
{
    public static string pinchObjGlasses = null;

    public static UnityEvent event_PinchGlasses;

    private string[] returnable = new string[4]; // csv파일에 기록할 내용을 담을 스트링형 배열

    void Start()
    {
        if (event_PinchGlasses == null)
            event_PinchGlasses = new UnityEvent();
    }

    private string[] GetReportPinchGlasses() // csv에 기록할 내용을 스트링형 배열로 가공
    {
        returnable[0] = "N/A";
        returnable[1] = "PinchGlasses";
        returnable[2] = pinchObjGlasses;
        returnable[3] = pinchObjGlasses;
        return returnable;
    }

    /*
    [PunRPC]
    void RPC_PinchGlasses(string newPinchObj)
    {
        pinchObjGlasses = newPinchObj;
        // 로그에 기록
        CSVManager.AppendToReport(GetReportPinchGlasses());      
        event_PinchGlasses.Invoke();
    }
    */
}
