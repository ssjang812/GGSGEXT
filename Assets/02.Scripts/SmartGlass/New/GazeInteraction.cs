using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInteraction : MonoBehaviour
{
    public GameObject chairPrefab;
    public GameObject tablePrefab;
    public GameObject smallSofaPrefab;
    public GameObject bigSofaPrefab;

    public float gyroPositionGain;
    public float swipePositionGain;
    public float headPositionGain;

    public LayerMask intSpaceLayerMask_Phone;
    public LayerMask intSpaceLayerMask_NearHand;
    public LayerMask spatialAwareness;

    private IMixedRealityEyeGazeProvider eyeTrackingProvider = null;
    private IMixedRealityEyeGazeProvider EyeTrackingProvider => eyeTrackingProvider ?? (eyeTrackingProvider = CoreServices.InputSystem?.EyeGazeProvider);
    private GameObject gazeOnObject;
    private GameObject manipObject;

    private float rotY;
    private float rotX;
    private float prerotY;
    private float prerotX;
    private float delRotY;
    private float delRotX;

    private Ray ray;
    private RaycastHit hitData;

    private GameObject newObject;
    private float scale;

    public GameObject GazeOnObject
    {
        get { return gazeOnObject; }
        set { gazeOnObject = value; }
    }

    public GameObject ManipObject
    {
        get { return manipObject; }
        set { manipObject = value; }
    }

    // start is called before the first frame update
    void Start()
    {
        gazeOnObject = null;
        manipObject = null;
        RPC_PhonetoGlasses.event_buttonUp.AddListener(GenerateWithGaze);
        RPC_PhonetoGlasses.event_pointerDown.AddListener(IsMoveCheck);
        RPC_PhonetoGlasses.event_pointerUp.AddListener(IsMoveFalse);
    }

    void Update()
    {
        HeadRotDelYXUpdate();

        gazeOnObject = EyeTrackingProvider.HitInfo.transform?.gameObject;

        //Debug.Log("gazeOnObject : " + gazeOnObject?.tag);
        //Debug.Log("manipObject : " + manipObject);

        FireInteractionSpaceRay();

        if (manipObject != null)
        {
            //Debug.Log(manipObject);
            switch(DeviceState.phoneControlMode)
            {
                case PhoneControlMode.PhoneSwipe:
                    MoveWithSwipe();
                break;
                case PhoneControlMode.PhoneGyro:
                    MoveWithGyro();
                break;
                case PhoneControlMode.GlassesGyro:
                    MoveWithHead();
                break;
            }
        }
    }

   
    // Interaction Space 검출 (손중앙, 손주변, 외부)
    private void FireInteractionSpaceRay()
    {
        if (EyeTrackingProvider.HitInfo.transform == null)
        {
            Debug.DrawRay(CoreServices.InputSystem.EyeGazeProvider.GazeOrigin, CoreServices.InputSystem.EyeGazeProvider.GazeDirection * 1000, Color.cyan);
        }

        //Debug.Log("FireInteracitonSpaceRay");
        ray = new Ray(CoreServices.InputSystem.EyeGazeProvider.GazeOrigin, CoreServices.InputSystem.EyeGazeProvider.GazeDirection);
        //if (Physics.Raycast(ray, out hitData, intSpaceLayerMask_Phone | intSpaceLayerMask_NearHand))

        if (Physics.Raycast(ray, out hitData, 50f, spatialAwareness))
        {
            Debug.Log(hitData.transform.gameObject.layer);
            Debug.Log(hitData.transform.name);
            // 손 주변부 검출
/*            if (hitData.transform.CompareTag("IntSpace_Phone"))
            {
                Debug.Log("IntSpace_Phone");
                DeviceState.interactionSpace = InteractionSpace.Phone;
            }
            else if (hitData.transform.CompareTag("IntSpace_NearHand"))
            {
                Debug.Log("IntSpace_NearHand");
                DeviceState.interactionSpace = InteractionSpace.NearHand;
            }*/
            if (hitData.transform.gameObject.CompareTag("IntSpace_Phone"))
            {
                //Debug.Log("IntSpace_Phone");
                DeviceState.interactionSpace = InteractionSpace.Phone;  //변할때만 바뀌도록 하면 더 효율이 좋을듯
            }
            else if (hitData.transform.gameObject.CompareTag("IntSpace_NearHand"))
            {
                //Debug.Log("IntSpace_NearHand");
                DeviceState.interactionSpace = InteractionSpace.NearHand;   //변할때만 바뀌도록 하면 더 효율이 좋을듯
            }
            
        }
        else
        {
            //Debug.Log("World");
            DeviceState.interactionSpace = InteractionSpace.World;
        }
    }
    

    private void GenerateWithGaze()
    {   
        if (EyeTrackingProvider.HitInfo.transform != null)
        {
            
            if (DeviceState.interactionSpace == InteractionSpace.Phone)
            {
                //don't genearte
            }
            else
            {
                if (DeviceState.interactionSpace == InteractionSpace.NearHand)
                {
                    //gen tiny
                    scale = 0.3f;
                }
                else if(DeviceState.interactionSpace == InteractionSpace.World)
                {
                    //gen big
                    scale = 1;
                }

                
                switch (DeviceState.furniture)
                {             
                    case Furniture.Chair:
                        Debug.Log("gen chair");
                        newObject = Instantiate(chairPrefab, EyeTrackingProvider.HitPosition + new Vector3(0, chairPrefab.transform.localScale.y / 3, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                        newObject.transform.localScale = new Vector3(scale, scale, scale);
                        break;
                    case Furniture.Table:
                        Debug.Log("gen table");
                        newObject = Instantiate(tablePrefab, EyeTrackingProvider.HitPosition + new Vector3(0, tablePrefab.transform.localScale.y / 3, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                        newObject.transform.localScale = new Vector3(scale, scale, scale);
                        break;
                    case Furniture.SmallSofa:
                        Debug.Log("gen small sofa");
                        newObject = Instantiate(smallSofaPrefab, EyeTrackingProvider.HitPosition + new Vector3(0, smallSofaPrefab.transform.localScale.y / 3, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                        newObject.transform.localScale = new Vector3(scale, scale, scale);
                        break;
                    case Furniture.BigSofa:
                        Debug.Log("gen small bigsofa");
                        newObject = Instantiate(bigSofaPrefab, EyeTrackingProvider.HitPosition + new Vector3(0, bigSofaPrefab.transform.localScale.y / 3, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                        newObject.transform.localScale = new Vector3(scale, scale, scale);
                        break;
                    default:
                        break;
                }
            }
            
        }
        else
        {
            Debug.Log(EyeTrackingProvider.HitInfo.transform);
        }
    }

    private void MoveWithGyro()
    {
        manipObject.transform.Translate(DeviceState.gyroDelta * gyroPositionGain, Space.World);
    }

    private void MoveWithSwipe()
    {
        Debug.Log("MoveWithSwipe");
        manipObject.transform.Translate(DeviceState.swipeDelta * swipePositionGain, Space.World);
    }

    private void MoveWithHead()
    {
        manipObject.transform.Translate(RotDelYXtoScrDelXZ() * headPositionGain, Space.World);
    }

    private void HeadRotDelYXUpdate()
    {
        rotY = CameraCache.Main.transform.rotation.y;
        rotX = CameraCache.Main.transform.rotation.x;
        delRotY = rotY - prerotY;
        delRotX = rotX - prerotX;
        prerotY = rotY;
        prerotX = rotX;
    }

    private Vector3 RotDelYXtoScrDelXZ()
    {
        return new Vector3(delRotY * Time.deltaTime, 0, -delRotX * Time.deltaTime);
    }

    private void IsMoveCheck()
    {
        Debug.Log("IsMoveCheck");
        if(GazeOnObject != null)
        {
            if (GazeOnObject.tag == "Movable")
            {
                manipObject = gazeOnObject;
                Debug.Log("IsMoveCheck : " + manipObject);
            }
            else
            {
                Debug.Log("Wall");
            }
        }
    }

    private void IsMoveFalse()
    {
        manipObject = null;
        Debug.Log("IsMoveFalse : " + manipObject);
    }
}
