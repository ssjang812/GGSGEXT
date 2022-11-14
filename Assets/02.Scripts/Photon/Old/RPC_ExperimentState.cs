using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RPC_ExperimentState : MonoBehaviour
{
    public enum Task
    {
        FindSameImage,
        FindSameObject,
        PlaceWithEyeGaze,
        RetrieveInfo
    }

    public enum Target
    {
        Sphere,
        Cube,
        Capsule,
        Cylinder
    }

    public static int trial; // 몇번째 테스크를 수행중인가
    public static Task taskNow; // 어떤 테스크인가
    public static Task taskFormal; // 이전에 어떤 테스크를 했는지 (다음 테스크 진행시 이전 까지 한 씬을 꺼줄때 필요)
    public static Target target; // 같은것 찾기 task에서 찾아야할 대상번호
    public static Target targetFormal;
    public static int targetPoint; // 배치 시나리오에서 배치해야될 위치번호

    public static UnityEvent event_StartExperiment; // 각 디바이스에서 호출시킬 함수를 리스너로 등록시켜놓으면 된다.
    public static UnityEvent event_FindSameImage;
    public static UnityEvent event_FindSameObject;
    public static UnityEvent event_PlaceWithEyeGaze;
    public static UnityEvent event_RetrieveInfo;
    public static UnityEvent event_NextTask;
    public static UnityEvent event_EndExperiment;

    private string[] returnable = new string[4]; // csv파일에 기록할 내용을 담을 스트링형 배열

    void Start()
    {
        if (event_StartExperiment == null)
            event_StartExperiment = new UnityEvent();

        if (event_FindSameImage == null)
            event_FindSameImage = new UnityEvent();

        if (event_FindSameObject == null)
            event_FindSameObject = new UnityEvent();

        if (event_PlaceWithEyeGaze == null)
            event_PlaceWithEyeGaze = new UnityEvent();

        if (event_RetrieveInfo == null)
            event_RetrieveInfo = new UnityEvent();

        if (event_NextTask == null)
            event_NextTask = new UnityEvent();

        if (event_EndExperiment == null)
            event_EndExperiment = new UnityEvent();
    }

    private string[] GetReportLine() // csv에 기록할 내용을 스트링형 배열로 가공
    {
        returnable[0] = trial.ToString();
        returnable[1] = taskNow.ToString();
        returnable[2] = target.ToString();
        returnable[3] = targetPoint.ToString();
        return returnable;
    }

    private string[] EndReportLine() // 정답맞췄을시, 다음테스크 넘어갈때 기록
    {
        returnable[0] = "End of Exp";
        returnable[1] = "N/A";
        returnable[2] = "N/A";
        returnable[3] = "N/A";
        return returnable;
    }

    private string[] ReportNextTask() // 실험종료 기록 내용
    {
        returnable[0] = "NextTask";
        returnable[1] = taskNow.ToString();
        returnable[2] = target.ToString();
        returnable[3] = targetPoint.ToString();
        return returnable;
    }

    [PunRPC]
    void RPC_SetTaskNum(int newTaskNum)
    {
        trial = newTaskNum;
    }

    [PunRPC]
    void RPC_SetTask(Task newTask)
    {
        taskNow = newTask;
    }

    [PunRPC]
    void RPC_SetFormalTask(Task task)
    {
        taskFormal = task;
    }

    [PunRPC]
    void RPC_SetFormalTarget(Target target)
    {
        targetFormal = target;
    }

    [PunRPC]
    void RPC_SetTarget(Target newTarget)
    {
        target = newTarget;
    }

    [PunRPC]
    void RPC_SetTargetPoint(int newTargetPoint)
    {
        targetPoint = newTargetPoint;
    }
    /*
    [PunRPC]
    void RPC_Trigger_StartExperiment()
    {
        Debug.Log("ReportCreated");
        CSVManager.CreateReport();
        event_StartExperiment.Invoke();
    }

    [PunRPC]
    void RPC_Trigger_FindSameImage()
    {
        // 기록 o
        Debug.Log("RPC_Trigger_FindSameImage");
        CSVManager.AppendToReport(GetReportLine());
        event_FindSameImage.Invoke();
    }

    [PunRPC]
    void RPC_Trigger_FindSameObject()
    {
        // 기록 o
        Debug.Log("RPC_Trigger_FindSameObject");
        CSVManager.AppendToReport(GetReportLine());
        event_FindSameObject.Invoke();
    }

    [PunRPC]
    void RPC_Trigger_PlaceWithEyeGaze()
    {
        // 기록 o
        Debug.Log("RPC_Trigger_PlaceWithEyeGaze");
        CSVManager.AppendToReport(GetReportLine());   
        event_PlaceWithEyeGaze.Invoke();
    }

    [PunRPC]
    void RPC_Trigger_RetrieveInfo()
    {
        // 기록 o
        Debug.Log("RPC_Trigger_RetrieveInfo");
        CSVManager.AppendToReport(GetReportLine());      
        event_RetrieveInfo.Invoke();
    }

    [PunRPC]
    void RPC_Trigger_NextTask()
    {
        CSVManager.AppendToReport(ReportNextTask());
        event_NextTask.Invoke();
    }

    [PunRPC]
    void RPC_Trigger_EndExperiment()
    {
        // 기록
        CSVManager.AppendToReport(EndReportLine());
        event_EndExperiment.Invoke();
    }
    */
}
