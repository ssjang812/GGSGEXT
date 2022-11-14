using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static RPC_ExperimentState;

public class ExperimentSyncer : MonoBehaviour
{
    private GameObject WorldEvent;
    private PhotonView PV;

    private GameObject findSameImageCanvas, findSameObjectCanvas, placeWithEyeGazeCanvas, retrieveInfoCanvas;
    //public TextMeshPro description;

    private GameObject sphereButton_FindSameImage, cubeButton_FindSameImage, capsuleButton_FindSameImage, cylinderButton_FindSameImage;
    private GameObject sphereButton_FindSameObject, cubeButton_FindSameObject, capsuleButton_FindSameObject, cylinderButton_FindSameObject;
    private GameObject sphereButton_PlaceWithEyeGaze, cubeButton_PlaceWithEyeGaze, capsuleButton_PlaceWithEyeGaze, cylinderButton_PlaceWithEyeGaze;
    private GameObject sphereButton_RetrieveInfo, cubeButton_RetrieveInfo, capsuleButton_RetrieveInfo, cylinderButton_RetrieveInfo;

    // Start is called before the first frame update
    void Start()
    {
        WorldEvent = GameObject.FindGameObjectWithTag("WorldEvent");
        PV = WorldEvent.GetComponent<PhotonView>();

        findSameImageCanvas = GameObject.FindGameObjectWithTag("FindSameImageCanvas");
        findSameObjectCanvas = GameObject.FindGameObjectWithTag("FindSameObjectCanvas");
        placeWithEyeGazeCanvas = GameObject.FindGameObjectWithTag("PlaceWithEyeGazeCanvas");
        retrieveInfoCanvas = GameObject.FindGameObjectWithTag("RetrieveInfoCanvas");

        findSameImageCanvas.SetActive(true);
        findSameObjectCanvas.SetActive(true);
        placeWithEyeGazeCanvas.SetActive(true);
        retrieveInfoCanvas.SetActive(true);

        sphereButton_FindSameImage = GameObject.FindWithTag("SphereButton_FindSameImage");
        cubeButton_FindSameImage = GameObject.FindWithTag("CubeButton_FindSameImage");
        capsuleButton_FindSameImage = GameObject.FindWithTag("CapsuleButton_FindSameImage");
        cylinderButton_FindSameImage = GameObject.FindWithTag("CylinderButton_FindSameImage");

        sphereButton_FindSameObject = GameObject.FindWithTag("SphereButton_FindSameObject");
        cubeButton_FindSameObject = GameObject.FindWithTag("CubeButton_FindSameObject");
        capsuleButton_FindSameObject = GameObject.FindWithTag("CapsuleButton_FindSameObject");
        cylinderButton_FindSameObject = GameObject.FindWithTag("CylinderButton_FindSameObject");

        sphereButton_PlaceWithEyeGaze = GameObject.FindWithTag("SphereButton_PlaceWithEyeGaze");
        cubeButton_PlaceWithEyeGaze = GameObject.FindWithTag("CubeSphereButton_PlaceWithEyeGaze");
        capsuleButton_PlaceWithEyeGaze = GameObject.FindWithTag("CapsuleButton_PlaceWithEyeGaze");
        cylinderButton_PlaceWithEyeGaze = GameObject.FindWithTag("CylinderButton_PlaceWithEyeGaze");

        sphereButton_RetrieveInfo = GameObject.FindWithTag("SphereButton_RetrieveInfo");
        cubeButton_RetrieveInfo = GameObject.FindWithTag("CubeButton_RetrieveInfo");
        capsuleButton_RetrieveInfo = GameObject.FindWithTag("CapsuleButton_RetrieveInfo");
        cylinderButton_RetrieveInfo = GameObject.FindWithTag("CylinderButton_RetrieveInfo");

        RPC_ExperimentState.event_StartExperiment.AddListener(SyncStartExperiment);
        RPC_ExperimentState.event_FindSameImage.AddListener(SyncSetFindSameImage);
        RPC_ExperimentState.event_FindSameObject.AddListener(SyncSetFindSameObject);
        RPC_ExperimentState.event_PlaceWithEyeGaze.AddListener(SyncSetPlaceWithEyeGaze);
        RPC_ExperimentState.event_RetrieveInfo.AddListener(SyncSetRetrieveInfo);
        RPC_ExperimentState.event_NextTask.AddListener(SyncNextTask);
        RPC_ExperimentState.event_EndExperiment.AddListener(SyncEndExperiment);

        sphereButton_FindSameImage.SetActive(false);
        cubeButton_FindSameImage.SetActive(false);
        capsuleButton_FindSameImage.SetActive(false);
        cylinderButton_FindSameImage.SetActive(false);

        sphereButton_FindSameObject.SetActive(false);
        cubeButton_FindSameObject.SetActive(false);
        capsuleButton_FindSameObject.SetActive(false);
        cylinderButton_FindSameObject.SetActive(false);

        sphereButton_PlaceWithEyeGaze.SetActive(false);
        cubeButton_PlaceWithEyeGaze.SetActive(false);
        capsuleButton_PlaceWithEyeGaze.SetActive(false);
        cylinderButton_PlaceWithEyeGaze.SetActive(false);

        sphereButton_RetrieveInfo.SetActive(false);
        cubeButton_RetrieveInfo.SetActive(false);
        capsuleButton_RetrieveInfo.SetActive(false);
        cylinderButton_RetrieveInfo.SetActive(false);

        findSameImageCanvas.SetActive(false);
        findSameObjectCanvas.SetActive(false);
        placeWithEyeGazeCanvas.SetActive(false);
        retrieveInfoCanvas.SetActive(false);
    }

    public void SyncStartExperiment()
    {
        //로컬에선 딱히 해줄게 없는듯
    }

    private void SyncSetFindSameImage()
    {
        findSameImageCanvas.SetActive(true);
    }

    private void SyncEndFindSameImage()
    {
        findSameImageCanvas.SetActive(false);
    }

    private void SyncSetFindSameObject()
    {
        findSameObjectCanvas.SetActive(true);

        switch (RPC_ExperimentState.target)
        {
            case Target.Sphere:
                sphereButton_FindSameObject.SetActive(true);
                break;
            case Target.Cube:
                cubeButton_FindSameObject.SetActive(true);
                break;
            case Target.Capsule:
                capsuleButton_FindSameObject.SetActive(true);
                break;
            case Target.Cylinder:
                cylinderButton_FindSameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void SyncEndFindSameObject()
    {
        switch (RPC_ExperimentState.targetFormal)
        {
            case Target.Sphere:
                sphereButton_FindSameObject.SetActive(false);
                break;
            case Target.Cube:
                cubeButton_FindSameObject.SetActive(false);
                break;
            case Target.Capsule:
                capsuleButton_FindSameObject.SetActive(false);
                break;
            case Target.Cylinder:
                cylinderButton_FindSameObject.SetActive(false);
                break;
            default:
                break;
        }
        findSameObjectCanvas.SetActive(false);
    }

    private void SyncSetPlaceWithEyeGaze()
    {
        placeWithEyeGazeCanvas.SetActive(true);
    }

    private void SyncEndPlaceWithEyeGaze()
    {
        placeWithEyeGazeCanvas.SetActive(false);
    }

    private void SyncSetRetrieveInfo()
    { 
        retrieveInfoCanvas.SetActive(true);
        switch (RPC_ExperimentState.target)
        {
            case Target.Sphere:
                sphereButton_RetrieveInfo.SetActive(true);
                break;
            case Target.Cube:
                cubeButton_RetrieveInfo.SetActive(true);
                break;
            case Target.Capsule:
                capsuleButton_RetrieveInfo.SetActive(true);
                break;
            case Target.Cylinder:
                cylinderButton_RetrieveInfo.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void SyncEndRetrieveInfo()
    {
        switch (RPC_ExperimentState.targetFormal)
        {
            case Target.Sphere:
                sphereButton_RetrieveInfo.SetActive(false);
                break;
            case Target.Cube:
                cubeButton_RetrieveInfo.SetActive(false);
                break;
            case Target.Capsule:
                capsuleButton_RetrieveInfo.SetActive(false);
                break;
            case Target.Cylinder:
                cylinderButton_RetrieveInfo.SetActive(false);
                break;
            default:
                break;
        }
        retrieveInfoCanvas.SetActive(false);
    }

    public void SyncNextTask() // 인터렉션을 처리하는곳에서 모든 인터랙션을 기록, 유효 인풋이 들어오면 다음 이 함수를 호출해서 다음단계로 진행
    {
        switch (RPC_ExperimentState.taskFormal)
        {
            case Task.FindSameImage:
                SyncEndFindSameImage();
                break;
            case Task.FindSameObject:
                SyncEndFindSameObject();
                break;
            case Task.PlaceWithEyeGaze:
                SyncEndPlaceWithEyeGaze();
                break;
            case Task.RetrieveInfo:
                SyncEndRetrieveInfo();
                break;
            default:
                break;
        }
    }

    private void SyncEndExperiment()
    {
        // 저장하고 종료
        Application.Quit();
    }
}
