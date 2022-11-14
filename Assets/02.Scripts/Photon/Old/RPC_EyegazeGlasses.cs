using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class RPC_EyegazeGlasses : MonoBehaviour
{
    public static string gazeOnObjGlasses = null;
    private string[] returnable = new string[4]; // csv파일에 기록할 내용을 담을 스트링형 배열

    /*  //이렇게하면 시선상태 변경에따라 시선인식하는 모든객체를 invoke 함, 인터렉션 필요한 이벤트를 따로하나씩 만들어서 그거만 콜하게 해줘야할듯
    public static UnityEvent event_GazeOnObjGlasses;
    public static UnityEvent event_GazeNullGlasses;
    */

    private string[] GetReportGazeOn() // csv에 기록할 내용을 스트링형 배열로 가공
    {
        returnable[0] = "N/A";
        returnable[1] = "GazeOn";
        returnable[2] = gazeOnObjGlasses;
        returnable[3] = gazeOnObjGlasses;
        return returnable;
    }

    private string[] GetReportGazeNull() // csv에 기록할 내용을 스트링형 배열로 가공
    {
        returnable[0] = "N/A";
        returnable[1] = "GazeNull";
        returnable[2] = "null";
        returnable[3] = "null";
        return returnable;
    }

    void Start()
    {
        /*
        if (event_GazeOnObjGlasses == null)
            event_GazeOnObjGlasses = new UnityEvent();

        if (event_GazeNullGlasses == null)
            event_GazeNullGlasses = new UnityEvent();
        */
    }
    /*
    [PunRPC]
    void RPC_GazeOnObj(string newGazeOnObject)
    {
        // 기록
        gazeOnObjGlasses = newGazeOnObject;
        CSVManager.AppendToReport(GetReportGazeOn());
        //event_GazeOnObjGlasses.Invoke();
    }

    [PunRPC]
    void RPC_GazeNull()
    {
        // 기록
        gazeOnObjGlasses = null;
        CSVManager.AppendToReport(GetReportGazeNull());
        //event_GazeNullGlasses.Invoke();
    }
    */
}
