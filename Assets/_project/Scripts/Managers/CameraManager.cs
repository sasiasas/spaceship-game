using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    enum VirtualCamera
    {
        NoCamera = -1,
        CockpitCamera = 0,
        FollowCamera,
        GunCamera,
        FrontCamera
    }

    [SerializeField]
    private List<GameObject> _virtualCameras;

    VirtualCamera CameraKeyPressed
    {
        get
        {
            for (int i = 0; i < _virtualCameras.Count; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i)) return (VirtualCamera)i;
            }

            return VirtualCamera.NoCamera;
        }
    }

    void Start()
    {
        SetActiveCamera(VirtualCamera.FollowCamera);
    }

    void Update()
    {
        VirtualCamera requestedCamera = CameraKeyPressed;
        if (requestedCamera != VirtualCamera.NoCamera) // Only update if a valid camera key is pressed
        {
            SetActiveCamera(requestedCamera);
        }
    }

    void SetActiveCamera(VirtualCamera activeCamera)
    {
        if (activeCamera == VirtualCamera.NoCamera)
        {
            Debug.Log("No camera activated.");
            return;
        }

        foreach (GameObject camera in _virtualCameras)
        {
            camera.SetActive(camera.tag.Equals(activeCamera.ToString()));
        }
        Debug.Log($"{activeCamera.ToString()} camera is active.");
    }
}
