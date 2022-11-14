using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    public GameObject Anchor;
    public GameObject Button;
    public GameObject Wall;
    public GameObject SmallWall;

    public void TurnOffUI()
    {
        Anchor.SetActive(false);
        Button.SetActive(false);
        Wall.GetComponent<MeshRenderer>().enabled = false;
        SmallWall.GetComponent<MeshRenderer>().enabled = false;
    }
}
