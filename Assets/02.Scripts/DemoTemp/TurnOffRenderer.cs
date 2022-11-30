using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffRenderer : MonoBehaviour
{
    public MeshRenderer[] TurnOffObject1;
    public GameObject[] TurnOffObject2;

    public void TurnOff1()
    {
        foreach(MeshRenderer renderer in TurnOffObject1)
        {
            renderer.enabled = false;
        }
        return;
    }

    public void TurnOn1()
    {
        foreach (MeshRenderer renderer in TurnOffObject1)
        {
            renderer.enabled = true;
        }
        return;
    }

    public void TurnOff2()
    {
        foreach (GameObject gameObject in TurnOffObject2)
        {
            gameObject.SetActive(false);
        }
        return;
    }

    public void TurnOn2()
    {
        foreach (GameObject gameObject in TurnOffObject2)
        {
            //Debug.Log("TurnOn");
            gameObject.SetActive(true);
        }
        return;
    }
}
