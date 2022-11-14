using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotConstraintOn : MonoBehaviour
{
    RotationAxisConstraint rotAxisConstraint;

    // FaceUserConstraint랑 RotationConstraint가 둘다있을때 같이 적용이안되는 버그가있는것 같다. 시작된후에 RotationConstraint를 켜주면 되는 것 같다.
    // 더웃긴건 켜져있는 스크립트를 껏다 키면안되고, "시작부터 꺼져있는 스크립트를 실행후 켜줘야만 된다.
    void Start()
    {
        rotAxisConstraint = gameObject.GetComponent<RotationAxisConstraint>();
        rotAxisConstraint.enabled = true;
    }
}
