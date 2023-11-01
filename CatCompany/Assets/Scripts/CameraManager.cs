using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float cameraSpeed = 10;

    public float mapSizeX = 10;


    private void Update()
    {
        moveCamera();
    }

    //Camera movement
    private void moveCamera()
    {
        transform.Translate(Input.GetAxis("Horizontal") * cameraSpeed * Time.deltaTime, 0, 0);
    }
}
