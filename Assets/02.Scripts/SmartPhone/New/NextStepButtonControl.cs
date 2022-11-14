using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextStepButtonControl : MonoBehaviour
{
    public PhotonView PV;
    public GameObject NextStepBtn;
    public float pressThreshHold = 1f;
    private float timer = 0.0f;
    private bool isPointerDown = false;

    void Start()
    {
        RPC_GlassestoPhone.event_oneTrialStart.AddListener(SetActiveTrue);
    }

    void Update()
    {
        if (isPointerDown)
        {
            timer += Time.deltaTime;
        }
        if (timer > pressThreshHold)
        {
            Debug.Log("1 sec!!!!");
            timer = 0;
            SetActiveFalse();
        }
    }

    public void OnNextStepButtonDown()
    {
        timer = 0.0f;
        isPointerDown = true;
    }

    public void OnNextStepButtonUp()
    {
        timer = 0.0f;
        isPointerDown = false;
    }

    private void SetActiveFalse()
    {
        NextStepBtn.SetActive(false);
        isPointerDown = false;
        PV.RPC("RPC_NextButtonDeactivated", RpcTarget.All);
    }

    private void SetActiveTrue()
    {
        NextStepBtn.SetActive(true);
        isPointerDown = false;
    }
}
