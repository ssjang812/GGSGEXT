using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPlaneGen : MonoBehaviour
{
    public GameObject phonePlane;

    private void Start()
    {
        phonePlane.SetActive(false);
    }

    void Update()
    {
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Right, out MixedRealityPose pose))
        {
            phonePlane.SetActive(true);
            phonePlane.transform.position = pose.Position;
            //Debug.Log("Hand Tracked");
        }
        else
        {
            if (phonePlane.activeSelf)
            {
                phonePlane.SetActive(false);
            }
        }
    }

    public void OnSourceDetected(SourceStateEventData eventData)
    {
        var hand = eventData.Controller as IMixedRealityHand;
        if (hand != null)
        {
            if (hand.TryGetJoint(TrackedHandJoint.IndexTip, out MixedRealityPose jointPose))
            {
                Debug.Log("Hand Tracked");
            }
        }
    }
}