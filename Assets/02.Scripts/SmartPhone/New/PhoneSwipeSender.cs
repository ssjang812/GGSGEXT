using Lean.Touch;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSwipeSender : MonoBehaviour
{
    public PhotonView PV;
    public LeanFingerFilter Use = new LeanFingerFilter(true);

    private void Update()
    {
        PV.RPC("RPC_SyncSwipeDelta", RpcTarget.All, DeltaXYtoXZ());
    }


    public Tuple<float, float> ParseScreenDelta()
    {
        var fingers = Use.UpdateAndGetFingers();
        Vector2 vector = LeanGesture.GetScaledDelta(fingers);
        return new Tuple<float, float>(vector.x, vector.y);
    }

    // RPC를 통해 보내줄 부분
    public Vector3 DeltaXYtoXZ()
    {
        Tuple<float, float> screenDeltaXY = ParseScreenDelta();
        return new Vector3(screenDeltaXY.Item1, 0, screenDeltaXY.Item2) * Time.deltaTime;
    }
}
