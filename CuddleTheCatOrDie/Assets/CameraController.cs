using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraController : MonoBehaviour
{

    CinemachineVirtualCamera virtualCamera;
    Animator animator;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        animator = GetComponent<Animator>();
    }
    public void SetFollow(GameObject target)
    {
        virtualCamera.m_Follow = target.transform;
    }

    public void StopFollow()
    {
        virtualCamera.m_Follow = null;
    }

    public void FocusOnExplodingCat(GameObject cat)
    {
        SetFollow(cat);
        animator.SetTrigger("openLen");
    }
}
