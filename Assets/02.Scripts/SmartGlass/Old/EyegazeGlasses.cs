using Microsoft.MixedReality.Toolkit.Input;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyegazeGlasses : MonoBehaviour
{
    private PhotonView PV;
    private EyeTrackingTarget eyeTrackingTarget;

    void Start()
    {
        PV = GameObject.FindGameObjectWithTag("WorldEvent").GetComponent<PhotonView>();
        eyeTrackingTarget = gameObject.GetComponent<EyeTrackingTarget>();
        eyeTrackingTarget.OnLookAtStart.AddListener(SetGazeOn);
        eyeTrackingTarget.OnLookAway.AddListener(SetGazeNull);

        /*
        RPC_EyegazeGlasses.event_GazeOnObjGlasses.AddListener(OnGazeOn);
        RPC_EyegazeGlasses.event_GazeNullGlasses.AddListener(OnGazeNull);
        */
    }

    public void SetGazeOn()
    {
        PV.RPC("RPC_GazeOnObj", RpcTarget.All, gameObject.tag);
    }

    public void SetGazeNull()
    {
        PV.RPC("RPC_GazeNull", RpcTarget.All);
    }

    /*  //시선기반인터렉션은 퉁쳐서하면안되고 필요할때마다 Event따로 만들어서 해당하는것에만 call하는 식으로.
    private void OnGazeOn()
    {
    }

    private void OnGazeNull()
    {
    }
    */
}