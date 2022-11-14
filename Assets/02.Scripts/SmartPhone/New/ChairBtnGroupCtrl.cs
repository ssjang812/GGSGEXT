using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairBtnGroupCtrl : MonoBehaviour
{
    public GameObject[] chairButton;
    void Start()
    {
        RPC_GlassestoPhone.event_oneTrialStart.AddListener(ActivateRandomButton);
    }

    private void ActivateRandomButton()
    {
        foreach(GameObject btn in chairButton)
        {
            btn.SetActive(false);
        }
        System.Random random = new System.Random();
        int index;
        index = random.Next(chairButton.Length);
        chairButton[index].SetActive(true);
    }
}
