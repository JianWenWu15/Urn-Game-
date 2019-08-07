using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera[] Cameras;
    public KeyCode RightArrow;
    public KeyCode LeftArrow;
    private int selectedCameraIndex;

    void Start()
    {
        DisableCameras();
        SelectCamera(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(RightArrow))
            SelectNextCamera();
        if (Input.GetKeyDown(LeftArrow))
            SelectPreviousCamera();
    }
    public void SelectNextCamera()
    {
        selectedCameraIndex = (selectedCameraIndex + 1) % Cameras.Length;
        SelectCamera(selectedCameraIndex);
    }
    public void SelectPreviousCamera()
    {
        selectedCameraIndex = (selectedCameraIndex - 1 + Cameras.Length) % Cameras.Length;
        SelectCamera(selectedCameraIndex);
    }
    public void SelectCamera(int cameraIndex)
    {
        if (cameraIndex >= 0 && cameraIndex < Cameras.Length)
        {
            Cameras[selectedCameraIndex].enabled = false;
            selectedCameraIndex = cameraIndex;
            Cameras[selectedCameraIndex].enabled = true;
        }
    }

    private void DisableCameras()
    {
        for (int i = 0; i < Cameras.Length; i++)
            Cameras[i].enabled = false;
    }
}
