using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RPC_GesturePhone : MonoBehaviour
{
    public static UnityEvent event_PinchPhone;
    public static UnityEvent event_OneFingerTapPhone;
    public static UnityEvent event_SwipeDownPhone;

    void Start()
    {
        if (event_PinchPhone == null)
            event_PinchPhone = new UnityEvent();

        if (event_OneFingerTapPhone == null)
            event_OneFingerTapPhone = new UnityEvent();

        if (event_SwipeDownPhone == null)
            event_SwipeDownPhone = new UnityEvent();
    }

    [PunRPC]
    void RPC_PinchPhone()
    {
        // 로그에 기록
        event_PinchPhone.Invoke();
    }

    [PunRPC]
    void RPC_OneFingerTapPhone()
    {
        // 로그에 기록
        event_OneFingerTapPhone.Invoke();
    }

    [PunRPC]
    void RPC_SwipeDownPhone()
    {
        // 로그에 기록
        event_SwipeDownPhone.Invoke();
    }
}
