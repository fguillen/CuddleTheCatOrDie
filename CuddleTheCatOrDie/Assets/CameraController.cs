using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraController : MonoBehaviour
{

    CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    public void SetFollow(GameObject target)
    {
        virtualCamera.m_Follow = target.transform;
    }

    public void StopFollow()
    {
        virtualCamera.m_Follow = null;
    }
}
