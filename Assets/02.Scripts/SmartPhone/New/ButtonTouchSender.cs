using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTouchSender : MonoBehaviour
{
    private PhotonView PV;
    private EventTrigger trigger;

    private void Start()
    {
        PV = GameObject.FindGameObjectWithTag("RPCFunction").GetComponent<PhotonView>();
        trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener((data) => { OnButtonUp((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnButtonUp(PointerEventData data)
    {
        PV.RPC("RPC_ButtonUp", RpcTarget.All, tag);
    }
}
