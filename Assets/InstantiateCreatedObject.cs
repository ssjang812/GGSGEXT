using Microsoft.MixedReality.Toolkit.Input;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCreatedObject : MonoBehaviour
{
    private EyeTrackingTarget eyeTrackingTarget;
    private GazeInteraction gazeInteraction;

    // Start is called before the first frame update
    void Start()
    {
        eyeTrackingTarget = gameObject.GetComponent<EyeTrackingTarget>();
        //Debug.Log(eyeTrackingTarget);

        eyeTrackingTarget.OnLookAtStart.AddListener(UpdateLookAtStart);
        eyeTrackingTarget.OnLookAway.AddListener(UpdateLookAway);
        gazeInteraction = GameObject.FindGameObjectWithTag("InputTechnique").GetComponent<GazeInteraction>();
        //Debug.Log("1");
    }

    void UpdateLookAtStart()
    {
        gazeInteraction.GazeOnObject = gameObject;
        DeviceState.isGazeOnObject = true;
        Debug.Log("UpdateLookAtStart");
    }

    void UpdateLookAway()
    {
        gazeInteraction.GazeOnObject = null;
        DeviceState.isGazeOnObject = false;
        Debug.Log("UpdateLookAway");
    }
}
