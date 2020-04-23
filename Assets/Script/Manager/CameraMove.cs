using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    Vector3 originTargetPos;

    private void Start()
    {
        originTargetPos = target.position;
    }

    public void Update()
    {
        Vector3 offSet = originTargetPos - target.position;
        Vector3 cameraPos = transform.position - offSet;
        this.transform.position = cameraPos;
        originTargetPos = target.position;
    }
}
