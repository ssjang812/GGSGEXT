using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RPC_GlassestoPhone : MonoBehaviour
{
    public static UnityEvent event_oneTrialStart;
    void Start()
    {
        if (event_oneTrialStart == null)
            event_oneTrialStart = new UnityEvent();
    }

    [PunRPC]
    void RPC_OneTrialStart()
    {
        event_oneTrialStart.Invoke();
        Debug.Log("RPC_OneTrialStart");
    }
}
