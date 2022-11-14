using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTouchSender : MonoBehaviour
{
    private PhotonView PV;

    private void Start()
    {
        PV = GameObject.FindGameObjectWithTag("RPCFunction").GetComponent<PhotonView>();
    }

    public void OnPointerDown()
    {
        PV.RPC("RPC_PointerDown", RpcTarget.All);
    }

    public void OnPointerUp()
    {
        PV.RPC("RPC_PointerUp", RpcTarget.All);
    }

    public void OnPhoneSwipeClick()
    {
        PV.RPC("RPC_PhoneSwipeClick", RpcTarget.All);
    }

    public void OnPhoneGyroClick()
    {
        PV.RPC("RPC_PhoneGyroClick", RpcTarget.All);
    }

    public void OnGlassesGyroClick()
    {
        PV.RPC("RPC_GlassesGyroClick", RpcTarget.All);
    }
}
