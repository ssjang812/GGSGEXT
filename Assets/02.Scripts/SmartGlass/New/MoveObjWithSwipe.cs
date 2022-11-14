using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjWithSwipe : MonoBehaviour
{
    //IN THIS PROJECT, THIS FUCTION IS INTEGRATED IN 'GazeInteraction.cs'

    //public float positionGain;
    //public float rotationGain;
    //private bool isPointerDown = false;

    //void Start()
    //{
    //    RPC_PhonetoGlasses.event_pointerDown.AddListener(SetPointerDownTrue);
    //    RPC_PhonetoGlasses.event_pointerUp.AddListener(SetPointerDownTrueFalse);
    //}

    //private void Update()
    //{
    //    if (ExperimentState.curTrialPhase == TrialPhase.FinePlacement && ExperimentState.curBlockTechnique == Technique.PhoneSwipe)
    //    {
    //        if (isPointerDown)
    //        {
    //            MoveWithSwipe();
    //        }
    //    }
    //    else if (ExperimentState.curTrialPhase == TrialPhase.Rotation && ExperimentState.curBlockTechnique == Technique.PhoneSwipe)
    //    {
    //        if (isPointerDown)
    //        {
    //            RoatateWithSwipe();
    //        }
    //    }
    //}

    //private void MoveWithSwipe()
    //{
    //        transform.Translate(DeviceState.swipeDelta * positionGain);
    //}

    //private void RoatateWithSwipe()
    //{
    //        transform.Rotate(new Vector3(0, DeviceState.swipeDelta.x, 0) * rotationGain);
    //}

    //private void SetPointerDownTrue()
    //{
    //    isPointerDown = true;
    //}

    //private void SetPointerDownTrueFalse()
    //{
    //    isPointerDown = false;
    //}
}
