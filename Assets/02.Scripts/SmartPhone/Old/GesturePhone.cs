using Lean.Touch;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// 고쳐야할것 : experience manager는 글래스에있는데 여기서 접근하고있음, 전체 흐름 코드 전면 체크필요
public class GesturePhone : MonoBehaviour
{
    public LeanFingerFilter Use = new LeanFingerFilter(true);

    private GameObject WorldEvent;
    private PhotonView PV;
    private ExperimentManager_Old experimentManager;


#if UNITY_EDITOR
    protected virtual void Reset()
    {
        Use.UpdateRequiredSelectable(gameObject);
    }
#endif
    protected virtual void Awake()
    {
        Use.UpdateRequiredSelectable(gameObject);
    }

    void Start()
    {
        WorldEvent = GameObject.FindGameObjectWithTag("WorldEvent");
        PV = WorldEvent.GetComponent<PhotonView>();
        experimentManager = GameObject.FindGameObjectWithTag("ExperimentManager").GetComponent<ExperimentManager_Old>();
    }



    protected virtual void Update()
	{
        // Get the fingers we want to use
        //var fingers = Use.GetFingers();
        var fingers = Use.UpdateAndGetFingers(); // 원래 윗줄이었는데 버전업되면서 바뀐것 같다. 일단 수정했는데 돌아가는지 확인은 안해봄

        // Calculate pinch scale, and make sure it's valid
        var pinchScale = LeanGesture.GetPinchScale(fingers);

		if (pinchScale > 1.13f)
		{
            Debug.Log("Pinch : " + pinchScale);
            PinchPhone();
        }
	}

	public void PinchPhone()
    {
        PV.RPC("RPC_PinchPhone", RpcTarget.All);

        // Cross Device 제스쳐 판별 -> Cross-device trigger function call (각 디바이스마다 다르게 Implementation)
        if (RPC_EyegazeGlasses.gazeOnObjGlasses != null)
        {
            // 로그에 기록
            // 만약 타겟 제스쳐 목표와 같다면 씬변경 + 추가로 로그에 기록
        }
    }

    public void OneFingerTapPhone(LeanFinger finger)
    {
        PV.RPC("RPC_OneFingerTapPhone", RpcTarget.All);
        
        // GazeTouch 발생여부 판단
        if(RPC_EyegazeGlasses.gazeOnObjGlasses != null)
        {
            PV.RPC("RPC_gazeTouch", RpcTarget.All);

            // retrieve info 시나리오(4)에서의 정답인지 판별
            if(RPC_ExperimentState.taskNow == RPC_ExperimentState.Task.RetrieveInfo)
            {
                switch (RPC_ExperimentState.target)
                {
                    case RPC_ExperimentState.Target.Sphere:
                        if (RPC_EyegazeGlasses.gazeOnObjGlasses == "Sphere_RetrieveInfo")
                            experimentManager.NextTaskPreprocess();
                        break;
                    case RPC_ExperimentState.Target.Cube:
                        if (RPC_EyegazeGlasses.gazeOnObjGlasses == "Cube_RetrieveInfo")
                            experimentManager.NextTaskPreprocess();
                        break;
                    case RPC_ExperimentState.Target.Capsule:
                        if (RPC_EyegazeGlasses.gazeOnObjGlasses == "Capsule_RetrieveInfo")
                            experimentManager.NextTaskPreprocess();
                        break;
                    case RPC_ExperimentState.Target.Cylinder:
                        if (RPC_EyegazeGlasses.gazeOnObjGlasses == "Cylinder_RetrieveInfo")
                            experimentManager.NextTaskPreprocess();
                        break;
                    default:
                        break;
                }
                // 다음 실험으로
                experimentManager.NextTaskPreprocess();
            }
        }
    }
    /*
    public void TwoFingerTap(LeanFinger finger)
    {
        textScript.SetText("TwoFingerTap");
        textScript2.SetText("GazeAtNull");
        Debug.Log("TwoFingerTap" + finger.TapCount);
        if (RPC_EyegazeState.gazeOnObject != null)
        {
            textScript2.SetText("GazeTwoFinger");
        }
    }
    */

    public void SwipeDownPhone(LeanFinger finger)
    {
        /*
        textScript.SetText("SwipeDown");
        textScript2.SetText("GazeAtNull");
        Debug.Log("SwipeDown");
        */

        PV.RPC("RPC_SwipeDownPhone", RpcTarget.All);
    }
}
