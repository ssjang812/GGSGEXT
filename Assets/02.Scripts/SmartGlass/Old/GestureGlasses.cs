using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureGlasses : MonoBehaviour
{
    private PhotonView PV;
    private ExperimentManager_Old experimentManager;
    private ObjectManipulator objectManipulator;

    private EyeTrackingTarget eyeTrackingTarget;

    void Start()
    {
        PV = GameObject.FindGameObjectWithTag("WorldEvent").GetComponent<PhotonView>();
        experimentManager = GameObject.FindGameObjectWithTag("ExperimentManager").GetComponent<ExperimentManager_Old>();
        objectManipulator = gameObject.GetComponent<ObjectManipulator>();
        objectManipulator.OnManipulationStarted.AddListener(OnGesture);
    }

 
    public void OnGesture(ManipulationEventData data)
    {
        PV.RPC("RPC_PinchGlasses", RpcTarget.All, gameObject.tag);

        //Find Same Object 시나리오(2번) 이고 정답인지 판단
        if(RPC_ExperimentState.taskNow == RPC_ExperimentState.Task.FindSameObject)
        {
            //정답이라고기록, 다음 스테이지로
            experimentManager.NextTaskPreprocess();

            switch (RPC_ExperimentState.target)
            {
                case RPC_ExperimentState.Target.Sphere:
                    if (gameObject.tag == "SphereButton_FindSameObject")
                        experimentManager.NextTaskPreprocess();
                    break;
                case RPC_ExperimentState.Target.Cube:
                    if (gameObject.tag == "CubeButton_FindSameObject")
                        experimentManager.NextTaskPreprocess();
                    break;
                case RPC_ExperimentState.Target.Capsule:
                    if (gameObject.tag == "CapsuleButton_FindSameObject")
                        experimentManager.NextTaskPreprocess();
                    break;
                case RPC_ExperimentState.Target.Cylinder:
                    if (gameObject.tag == "CylinderButton_FindSameObject")
                        experimentManager.NextTaskPreprocess();
                    break;
                default:
                    break;
            }
        }
    }
}
