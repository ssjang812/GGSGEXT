using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static RPC_ExperimentState;

public class ExperimentManager_Old : MonoBehaviour //메인함수와 같은역할을하니 실행순서를 맨 마지막으로 설정해야 문제가없다. (다른 스크립트들의 설정값이 다셋팅된후 구동시작)
{
    private GameObject WorldEvent;
    private PhotonView PV;

    private GameObject findSameImageScene, findSameObjectScene, placeWithEyeGazeScene, retrieveInfoScene, expStartButton, practiceSelectButton;
    public TextMeshPro description;
    private List<Task> taskList; // 리스트를 전부 서버에 넘겨주려면 for 문으로 값을 하나하나 다 넘겨줘야할듯. 일단 그냥 로컬에서 하자. -> 끝나는 체크를 로컬에서 해줘야함

    private GameObject sphere_FindSameImage, cube_FindSameImage, capsule_FindSameImage, cylinder_FindSameImage;
    private GameObject sphere_FindSameObject, cube_FindSameObject, capsule_FindSameObject, cylinder_FindSameObject;
    private GameObject spot1_PlaceWithEyeGaze, spot2_PlaceWithEyeGaze, spot3_PlaceWithEyeGaze, spot4_PlaceWithEyeGaze;
    private GameObject sphere_RetrieveInfo, cube_RetrieveInfo, capsule_RetrieveInfo, cylinder_RetrieveInfo;


    // Start is called before the first frame update
    void Start()
    {
        WorldEvent = GameObject.FindGameObjectWithTag("WorldEvent");
        PV = WorldEvent.GetComponent<PhotonView>();

        findSameImageScene = GameObject.FindGameObjectWithTag("FindSameImageScene");
        findSameObjectScene = GameObject.FindGameObjectWithTag("FindSameObjectScene");
        placeWithEyeGazeScene = GameObject.FindGameObjectWithTag("PlaceWithEyeGazeScene");
        retrieveInfoScene = GameObject.FindGameObjectWithTag("RetrieveInfoScene");
        expStartButton = GameObject.FindGameObjectWithTag("ExpStartButton");
        practiceSelectButton = GameObject.FindGameObjectWithTag("PracticeSelectButton");

        findSameImageScene.SetActive(true);
        findSameObjectScene.SetActive(true);
        placeWithEyeGazeScene.SetActive(true);
        retrieveInfoScene.SetActive(true);

        sphere_FindSameImage = GameObject.FindWithTag("Sphere_FindSameImage");
        cube_FindSameImage = GameObject.FindWithTag("Cube_FindSameImage");
        capsule_FindSameImage = GameObject.FindWithTag("Capsule_FindSameImage");
        cylinder_FindSameImage = GameObject.FindWithTag("Cylinder_FindSameImage");

        /* 궂이 안가져와도 될듯하다. 여기선 씬형태를 바꾸는거지, 인터렉션 처리는 다른곳에서 하기때문
        sphere_FindSameObject = GameObject.FindWithTag("Sphere_FindSameObject");
        cube_FindSameObject = GameObject.FindWithTag("Cube_FindSameObject");
        capsule_FindSameObject = GameObject.FindWithTag("Capsule_FindSameObject");
        cylinder_FindSameObject = GameObject.FindWithTag("Cylinder_FindSameObject");

        spot1_PlaceWithEyeGaze = GameObject.FindWithTag("Spot1_PlaceWithEyeGaze");
        spot2_PlaceWithEyeGaze = GameObject.FindWithTag("Spot2_PlaceWithEyeGaze");
        spot3_PlaceWithEyeGaze = GameObject.FindWithTag("Spot3_PlaceWithEyeGaze");
        spot4_PlaceWithEyeGaze = GameObject.FindWithTag("Spot4_PlaceWithEyeGaze");

        sphere_RetrieveInfo = GameObject.FindWithTag("Sphere_RetrieveInfo");
        cube_RetrieveInfo = GameObject.FindWithTag("Cube_RetrieveInfo");
        capsule_RetrieveInfo = GameObject.FindWithTag("Capsule_RetrieveInfo");
        cylinder_RetrieveInfo = GameObject.FindWithTag("Cylinder_RetrieveInfo");
        */

        RPC_ExperimentState.event_FindSameImage.AddListener(SetFindSameImage);
        RPC_ExperimentState.event_FindSameObject.AddListener(SetFindSameObject);
        RPC_ExperimentState.event_PlaceWithEyeGaze.AddListener(SetPlaceWithEyeGaze);
        RPC_ExperimentState.event_RetrieveInfo.AddListener(SetRetrieveInfo);
        RPC_ExperimentState.event_NextTask.AddListener(NextTask);
        RPC_ExperimentState.event_EndExperiment.AddListener(EndExperiment);

        
        sphere_FindSameImage.SetActive(false);
        cube_FindSameImage.SetActive(false);
        capsule_FindSameImage.SetActive(false);
        cylinder_FindSameImage.SetActive(false);

        findSameImageScene.SetActive(false);
        findSameObjectScene.SetActive(false);
        placeWithEyeGazeScene.SetActive(false);
        retrieveInfoScene.SetActive(false);

        description.text = "오른쪽에 위치한 네 개의 버튼을 통해 \n각 테스크에 대한 수행연습을 할 수 있습니다.\n\n연습을 충분히 하셨다면 상단의 버튼을 눌러 실험참여를 시작해 주세요.";
    }

    // 동기화는 중요 데이터, 각 이벤트의 발생여부, 데이터 기록과 같이 각 디바이스에서 동시에 일어나야하는것들만
    // 실험의 흐름과 다음으로 진행여부 판단과같은 결정부는 둘중 한곳에서만 해야지 혼서이 생기지 않는다. -> 로컬에서 진행하고 결과만 동기화
    public void StartExperiment()
    {
        PV.RPC("RPC_Trigger_StartExperiment", RpcTarget.All);

        expStartButton.SetActive(false);
        practiceSelectButton.SetActive(false);

        taskList = new List<Task>();
        for (int j = 0; j < 10; j++)
        {
            taskList.Add(Task.FindSameImage);
            taskList.Add(Task.FindSameObject);
            taskList.Add(Task.PlaceWithEyeGaze);
            taskList.Add(Task.RetrieveInfo);
        }

        PV.RPC("RPC_SetTaskNum", RpcTarget.All, 41 - taskList.Count);
        int randomIndex = Random.Range(0, taskList.Count);
        Task task = taskList[randomIndex];
        PV.RPC("RPC_SetTask", RpcTarget.All, task);
        taskList.RemoveAt(randomIndex);

        switch (task)
        {
            case Task.FindSameImage:
                PV.RPC("RPC_SetTarget", RpcTarget.All, (Target)Random.Range(0, 4));
                PV.RPC("RPC_SetTargetPoint", RpcTarget.All, 999);
                PV.RPC("RPC_Trigger_FindSameImage", RpcTarget.All);
                break;
            case Task.FindSameObject:
                PV.RPC("RPC_SetTarget", RpcTarget.All, (Target)Random.Range(0, 4));
                PV.RPC("RPC_SetTargetPoint", RpcTarget.All, 999);
                PV.RPC("RPC_Trigger_FindSameObject", RpcTarget.All);
                break;
            case Task.PlaceWithEyeGaze:
                PV.RPC("RPC_SetTarget", RpcTarget.All, (Target)Random.Range(0, 4));
                PV.RPC("RPC_SetTargetPoint", RpcTarget.All, (int)Random.Range(0, 4));
                PV.RPC("RPC_Trigger_PlaceWithEyeGaze", RpcTarget.All);
                break;
            case Task.RetrieveInfo:
                PV.RPC("RPC_SetTarget", RpcTarget.All, (Target)Random.Range(1, 5));
                PV.RPC("RPC_SetTargetPoint", RpcTarget.All, 999);
                PV.RPC("RPC_Trigger_RetrieveInfo", RpcTarget.All);
                break;
            default:
                break;
        }
    }

    private void SetFindSameImage()
    {
        findSameImageScene.SetActive(true);

        switch (RPC_ExperimentState.target)
        {
            case Target.Sphere:
                sphere_FindSameImage.SetActive(true);
                break;
            case Target.Cube:
                cube_FindSameImage.SetActive(true);
                break;
            case Target.Capsule:
                capsule_FindSameImage.SetActive(true);
                break;
            case Target.Cylinder:
                cylinder_FindSameImage.SetActive(true);
                break;
            default:
                break;
        }

        //그중 셋팅된 조건에 일치하는 인풋이 들어오면 기록후 다음으로 진행 (외부에서 next task를 호출) -> 네가지 전부
    }

    private void EndFindSameImage()
    {
        switch (RPC_ExperimentState.targetFormal)
        {
            case Target.Sphere:
                sphere_FindSameImage.SetActive(false);
                break;
            case Target.Cube:
                cube_FindSameImage.SetActive(false);
                break;
            case Target.Capsule:
                capsule_FindSameImage.SetActive(false);
                break;
            case Target.Cylinder:
                cylinder_FindSameImage.SetActive(false);
                break;
            default:
                break;
        }
        findSameImageScene.SetActive(false);
    }

    private void SetFindSameObject()
    {
        findSameObjectScene.SetActive(true);
    }

    private void EndFindSameObject()
    {
        findSameObjectScene.SetActive(false);
    }

    private void SetPlaceWithEyeGaze()
    {
        placeWithEyeGazeScene.SetActive(true);
    }

    private void EndPlaceWithEyeGaze()
    {
        placeWithEyeGazeScene.SetActive(false);
    }

    private void SetRetrieveInfo()
    {
        retrieveInfoScene.SetActive(true);
    }

    private void EndRetrieveInfo()
    {
        retrieveInfoScene.SetActive(false);
    }

    //정답맞추면 로컬에서 이 함수를 콜해주면됨
    public void NextTaskPreprocess() // next task 이전에 처리해줘야할 것들 처리 (기기마다 실행속도가 다를거기때문에 완전 미리해줘야할것들)
    {
        if (taskList.Count == 0) // 실험이 종료될 상황인지 체크, 선정한후에 리스트에서 삭제하므로 이전함수 call에서 리스트가 하나 줄어든 상태이다.
        {
            PV.RPC("RPC_Trigger_EndExperiment", RpcTarget.All);
        }
        else
        {
            PV.RPC("RPC_SetFormalTask", RpcTarget.All, RPC_ExperimentState.taskNow); //
            PV.RPC("RPC_SetFormalTarget", RpcTarget.All, RPC_ExperimentState.target);
            PV.RPC("RPC_Trigger_NextTask", RpcTarget.All);
        }
    }

    private void NextTask() // 인터렉션을 처리하는곳에서 모든 인터랙션을 기록, 유효 인풋이 들어오면 다음 이 함수를 호출해서 다음단계로 진행
    {
        switch (RPC_ExperimentState.taskFormal) // 새로운거 열기전에 이전꺼를 꺼주기
        {
            case Task.FindSameImage:
                EndFindSameImage();
                break;
            case Task.FindSameObject:
                EndFindSameObject();
                break;
            case Task.PlaceWithEyeGaze:
                EndPlaceWithEyeGaze();
                break;
            case Task.RetrieveInfo:
                EndRetrieveInfo();
                break;
            default:
                break;
        }

        PV.RPC("RPC_SetTaskNum", RpcTarget.All, 41 - taskList.Count);
        int randomIndex = Random.Range(0, taskList.Count);
        Task task = taskList[randomIndex];
        PV.RPC("RPC_SetTask", RpcTarget.All, task);
        taskList.RemoveAt(randomIndex);

        switch (task) // 스타트와 동일로 업데이트
        {
            case Task.FindSameImage:
                SetFindSameImage();
                break;
            case Task.FindSameObject:
                SetFindSameObject();
                break;
            case Task.PlaceWithEyeGaze:
                SetPlaceWithEyeGaze();
                break;
            case Task.RetrieveInfo:
                SetRetrieveInfo();
                break;
            default:
                break;
        }
    }

    private void EndExperiment()
    {
        // 저장하고 종료
        Application.Quit();
    }
}
