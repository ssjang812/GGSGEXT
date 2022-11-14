using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject[] box;
    private void Start()
    {
        /*
        Debug.Log(Vector3.Distance(box[0].transform.position, box[1].transform.position));
        Debug.Log(Vector3.Distance(box[0].transform.position, box[2].transform.position));
        Debug.Log(Vector3.Angle(box[0].transform.forward, box[1].transform.forward));
        Debug.Log(Vector3.Angle(box[0].transform.forward, box[2].transform.forward));
        */
    }

    private void Update()
    {
        //Debug.Log(Vector3.Distance(box[0].transform.position, box[1].transform.position));
        //Debug.Log(Vector3.Angle(box[0].transform.forward, box[1].transform.forward));
        // 오차거리 0.15
        // 오차각도 5도
    }


    public void onPointerDown()
    {
        Debug.Log("Pointer down!");
    }

    public void onPointerUp()
    {
        Debug.Log("Pointer up!");
    }

    public void Test()
    {
        Debug.Log("Test!");
    }
}
