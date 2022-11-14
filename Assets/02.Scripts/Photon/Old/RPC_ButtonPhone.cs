using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RPC_ButtonPhone : MonoBehaviour
{
    public static string onClickButtonPhone = null;
    public static string onPointerUpButtonPhone = null;

    public static UnityEvent event_onClickButtonPhone;
    public static UnityEvent event_onPointerUpButtonPhone;

    private string[] returnable = new string[4]; // csv파일에 기록할 내용을 담을 스트링형 배열

    void Start()
    {
        if (event_onClickButtonPhone == null)
            event_onClickButtonPhone = new UnityEvent();

        if (event_onPointerUpButtonPhone == null)
            event_onPointerUpButtonPhone = new UnityEvent();
    }

    private string[] ReportOnClickButtonPhone() // csv에 기록할 내용을 스트링형 배열로 가공
    {
        returnable[0] = "N/A";
        returnable[1] = "OnClickButtonPhone";
        returnable[2] = onClickButtonPhone;
        returnable[3] = onClickButtonPhone;
        return returnable;
    }

    private string[] ReportOnPointerUpButtonPhone() // csv에 기록할 내용을 스트링형 배열로 가공
    {
        returnable[0] = "N/A";
        returnable[1] = "OnPointerUpButtonPhone";
        returnable[2] = onPointerUpButtonPhone;
        returnable[3] = onPointerUpButtonPhone;
        return returnable;
    }

    /*
    [PunRPC]
    void RPC_onClickButtonPhone(string newOnClickButton)
    {
        // 로그에 기록
        onClickButtonPhone = newOnClickButton;
        CSVManager.AppendToReport(ReportOnClickButtonPhone());
        event_onClickButtonPhone.Invoke();
    }

    [PunRPC]
    void RPC_onPointerUpPhone(string newOnPointerUpButton)
    {
        // 로그에 기록
        onPointerUpButtonPhone = newOnPointerUpButton;
        CSVManager.AppendToReport(ReportOnPointerUpButtonPhone());
        event_onPointerUpButtonPhone.Invoke();
    }
    */
}
