using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// 고쳐야할것 : experience manager는 글래스에있는데 여기서 접근하고있음, 전체 흐름 코드 전면 체크필요
public class ButtonPhone : MonoBehaviour
{
    private PhotonView PV;
    private ExperimentManager_Old experimentManager;
    private Button button;
    private EventTrigger eventTrigger;
    private bool t4TargetFlag;
    private bool t4PointFlag;

    void Start()
    {
        PV = GameObject.FindGameObjectWithTag("WorldEvent").GetComponent<PhotonView>();
        experimentManager = GameObject.FindGameObjectWithTag("ExperimentManager").GetComponent<ExperimentManager_Old>();
        button = gameObject.GetComponent<Button>();
        eventTrigger = gameObject.GetComponent<EventTrigger>();
        t4TargetFlag = false;
        t4PointFlag = false;

        button.onClick.AddListener(OnButtonClick);

        EventTrigger.Entry entryPointerUp = new EventTrigger.Entry();
        entryPointerUp.eventID = EventTriggerType.PointerUp;
        entryPointerUp.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
        eventTrigger.triggers.Add(entryPointerUp);
    }

    void OnButtonClick()
    {
        PV.RPC("RPC_onClickButtonPhone", RpcTarget.All, gameObject.tag);

        //Find Same Image 시나리오(1번) 이고 정답인지 판단
        if (RPC_ExperimentState.taskNow == RPC_ExperimentState.Task.FindSameImage)
        {
            switch (RPC_ExperimentState.target)
            {
                case RPC_ExperimentState.Target.Sphere:
                    if (gameObject.tag == "SphereButton_FindSameImage")
                        experimentManager.NextTaskPreprocess();
                    break;
                case RPC_ExperimentState.Target.Cube:
                    if (gameObject.tag == "CubeButton_FindSameImage")
                        experimentManager.NextTaskPreprocess();
                    break;
                case RPC_ExperimentState.Target.Capsule:
                    if (gameObject.tag == "CapsuleButton_FindSameImage")
                        experimentManager.NextTaskPreprocess();
                    break;
                case RPC_ExperimentState.Target.Cylinder:
                    if (gameObject.tag == "CylinderButton_FindSameImage")
                        experimentManager.NextTaskPreprocess();
                    break;
                default:
                    break;
            }
        }
    }

    void OnPointerUp(BaseEventData baseEventData)
    {
        PV.RPC("RPC_onPointerUpPhone", RpcTarget.All, gameObject.tag);

        if(RPC_EyegazeGlasses.gazeOnObjGlasses != null)
        {
            PV.RPC("RPC_touchGaze", RpcTarget.All, gameObject.tag);
            //Place with eyegaze 시나리오(3번) 이고 정답인지 판단 (타겟에 맞는 버튼을눌렀고 시선은 맞는 위치를 보고있는지)
            if (RPC_ExperimentState.taskNow == RPC_ExperimentState.Task.PlaceWithEyeGaze)
            {
                switch (RPC_ExperimentState.target)
                {
                    case RPC_ExperimentState.Target.Sphere:
                        if (gameObject.tag == "SphereButton_PlaceWithEyeGaze")
                            t4TargetFlag = true;
                        break;
                    case RPC_ExperimentState.Target.Cube:
                        if (gameObject.tag == "CubeButton_PlaceWithEyeGaze")
                            t4TargetFlag = true;
                        break;
                    case RPC_ExperimentState.Target.Capsule:
                        if (gameObject.tag == "CapsuleButton_PlaceWithEyeGaze")
                            t4TargetFlag = true;
                        break;
                    case RPC_ExperimentState.Target.Cylinder:
                        if (gameObject.tag == "CylinderButton_PlaceWithEyeGaze")
                            t4TargetFlag = true;
                        break;
                    default:
                        break;
                }

                switch (RPC_ExperimentState.targetPoint)
                {
                    case 1:
                        if (RPC_EyegazeGlasses.gazeOnObjGlasses == "Spot1_PlaceWithEyeGaze")
                            t4PointFlag = true;
                        break;
                    case 2:
                        if (RPC_EyegazeGlasses.gazeOnObjGlasses == "Spot2_PlaceWithEyeGaze")
                            t4PointFlag = true;
                        break;
                    case 3:
                        if (RPC_EyegazeGlasses.gazeOnObjGlasses == "Spot3_PlaceWithEyeGaze")
                            t4PointFlag = true;
                        break;
                    case 4:
                        if (RPC_EyegazeGlasses.gazeOnObjGlasses == "Spot4_PlaceWithEyeGaze")
                            t4PointFlag = true;
                        break;
                    default:
                        break;
                }

                if (t4TargetFlag && t4PointFlag)
                    experimentManager.NextTaskPreprocess();

                t4TargetFlag = false;
                t4PointFlag = false;
            }
        }   
    }
}
