using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RPC_PhonetoGlasses : MonoBehaviour
{


    /*
    public static UnityEvent event_syncSwipeDelta;
    public static UnityEvent event_syncGyroDelta;

    public static UnityEvent event_chairButtonDown;
        */
    public static UnityEvent event_chairButtonUp;
    public static UnityEvent event_buttonUp;
    public static UnityEvent event_PhoneSwipeButtonDown;
    public static UnityEvent event_PhoneSwipeButtonUp;
    public static UnityEvent event_PhoneGyroButtonDown;
    public static UnityEvent event_PhoneGyroButtonUp;
    public static UnityEvent event_GlassesGyroButtonDown;
    public static UnityEvent event_GlassesGyroButtonUp;
    public static UnityEvent event_pointerDown;
    public static UnityEvent event_pointerUp;
    public static UnityEvent event_onPhoneSwipeClick;
    public static UnityEvent event_onPhoneGyroClick;
    public static UnityEvent event_onGlassesGyroClick;

    void Start()
    {
        /*
        if (event_syncSwipeDelta == null)
            event_syncSwipeDelta = new UnityEvent();
        if (event_syncGyroDelta == null)
            event_syncGyroDelta = new UnityEvent();

        if (event_chairButtonDown == null)
            event_chairButtonDown = new UnityEvent();
                */

        if (event_chairButtonUp == null)
            event_chairButtonUp = new UnityEvent();

        if (event_buttonUp == null)
            event_buttonUp = new UnityEvent();

        if (event_onPhoneSwipeClick == null)
            event_onPhoneSwipeClick = new UnityEvent();
        if (event_onPhoneGyroClick == null)
            event_onPhoneGyroClick = new UnityEvent();
        if (event_onGlassesGyroClick == null)
            event_onGlassesGyroClick = new UnityEvent();

        if (event_pointerDown == null)
            event_pointerDown = new UnityEvent();
        if (event_pointerUp == null)
            event_pointerUp = new UnityEvent();
    }

    [PunRPC]
    void RPC_SyncSwipeDelta(Vector3 input)
    {
        DeviceState.swipeDelta = input;
        //event_syncSwipeDelta.Invoke();
    }

    [PunRPC]
    void RPC_SyncGyroDelta(Vector3 input)
    {
        DeviceState.gyroDelta = input;
        //event_syncGyroDelta.Invoke();
    }

    //[PunRPC]
    //void RPC_ChairButtonDown()
    //{
    //    DeviceState.isGenerateObjectButtonPressed = true;
    //    event_chairButtonDown.Invoke();
    //    Debug.Log("RPC_ChairButtonDown!");
    //}

    [PunRPC]
    void RPC_ChairButtonUp()
    {
        DeviceState.isGenerateObjectButtonPressed = false;
        event_chairButtonUp.Invoke();
        //Debug.Log("RPC_ChairButtonUp!");
    }
    [PunRPC]
    void RPC_ButtonUp(string tag)
    {
        DeviceState.isGenerateObjectButtonPressed = false;
        switch (tag)
        {
            case "ChairBtn":
                DeviceState.furniture = Furniture.Chair;
                break;
            case "TableBtn":
                DeviceState.furniture = Furniture.Table;
                break;
            case "SmallSofaBtn":
                DeviceState.furniture = Furniture.SmallSofa;
                break;
            case "BigSofaBtn":
                DeviceState.furniture = Furniture.BigSofa;
                break;
            default:
                break;
        }
        event_buttonUp.Invoke();
        //Debug.Log("RPC_ChairButtonUp!");
    }


    [PunRPC]
    void RPC_PointerDown()
    {
        event_pointerDown.Invoke();
        Debug.Log("RPC_PointerDown!");
    }

    [PunRPC]
    void RPC_PointerUp()
    {
        event_pointerUp.Invoke();
        //Debug.Log("RPC_PointerUp!");
    }


    [PunRPC]
    void RPC_PhoneSwipeClick()
    {
        DeviceState.phoneControlMode = PhoneControlMode.PhoneSwipe;
        event_onPhoneSwipeClick.Invoke();
        //Debug.Log("RPC_OnPhoneSwipeClick!");
    }

    [PunRPC]
    void RPC_PhoneGyroClick()
    {
        DeviceState.phoneControlMode = PhoneControlMode.PhoneGyro;
        event_onPhoneGyroClick.Invoke();
        //Debug.Log("RPC_OnPhoneGyroClick!");
    }

    [PunRPC]
    void RPC_GlassesGyroClick()
    {
        DeviceState.phoneControlMode = PhoneControlMode.GlassesGyro;
        event_onGlassesGyroClick.Invoke();
        //Debug.Log("RPC_OnGlassesGyroClick!");
    }
}
