using System.Collections;
using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineBrain _brain;
    public CinemachineVirtualCamera _virtualCamera;
    Transform _target;

    private void Awake()
    {
        _brain = GetComponent<Cinemachine.CinemachineBrain>();
        //we dont need to reference vcam brain outomaticly select active camera on scene
        _virtualCamera.LookAt.LookAt(_target);
        _virtualCamera.Follow = _target;
    }
}
