using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineBlendControl : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera NormalVCam;
    [SerializeField] private CinemachineVirtualCamera ZoomedOutVCam;

    [SerializeField] private bool Zoomed;

    [SerializeField] private GameObject DolphinObj;

    private void Awake()
    {
        Zoomed = true;
        DolphinObj = GameObject.FindGameObjectWithTag("Dolphin");
    }

    private void Update()
    {
        if((!DolphinControl.InWater) || (DolphinControl.InWater && DolphinObj.transform.position.y < -6.5f))
        {
            Zoomed = false;
        }
        else
        {
            Zoomed = true;
        }


        SwitchCamPriority();
    }

    private void SwitchCamPriority()
    {
        if (Zoomed)
        {
            ZoomedOutVCam.Priority = 0;
            NormalVCam.Priority = 1;
        }
        else
        {
            ZoomedOutVCam.Priority = 1;
            NormalVCam.Priority = 0;
        }
    }
}
