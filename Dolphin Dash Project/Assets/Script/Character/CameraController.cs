using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_Character;
    private CinemachineVirtualCamera m_Vcam;
    [SerializeField] private float MinOrthoSize;
    [SerializeField] private float MaxOrthoSize;
    //[SerializeField] private float ZoomInLerpRate;
    //[SerializeField] private float ZoomOutLerpRate;
    [SerializeField] private float LerpTime;
    private float FOVSize = 6;

    private void Awake()
    {
        m_Vcam = GetComponent<CinemachineVirtualCamera>();
        m_Vcam.m_Lens.OrthographicSize = FOVSize;

        
    }

    private void Update()
    {
        //Camera.main.transform.position = new Vector3(m_Character.position.x, transform.position.y, transform.position.z);
        Mathf.Clamp(FOVSize, 4, 6);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            FOVSize -= Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //CameraPan(MinOrthoSize, MaxOrthoSize);
            FOVSize = 6;
        }

        m_Vcam.m_Lens.OrthographicSize = FOVSize;
    }


    //private void CameraPan(float InitialVal, float TargetVal)
    //{
    //    float EndTime = 0;

    //    if(EndTime < LerpTime)
    //    {
    //        m_Vcam.m_Lens.OrthographicSize = Mathf.Lerp(InitialVal, TargetVal, EndTime / LerpTime);
    //        EndTime += Time.deltaTime;
    //    }
    //}

}
