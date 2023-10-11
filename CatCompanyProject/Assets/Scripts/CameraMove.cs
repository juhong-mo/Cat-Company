using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // camera move variable
    public float speed = 10f;
    float xMove = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        // Move camera to direction key input
        xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(xMove, 0, 0);

    }
}
