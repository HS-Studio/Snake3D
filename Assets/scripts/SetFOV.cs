using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFOV : MonoBehaviour
{
    private Camera cam;

    float designAspect = 1.13f;
    
    void Start()
    {
        cam = GetComponent<Camera>();

        //designAspect = 4 / 3; // We'll be using 3 by 2 aspect ratio in Portrait mode
        // "Aspect" is width divided by height

        float cameraHorizontalFOV = cam.aspect * cam.fieldOfView;

        float horizontalDesignFOV = designAspect * cam.fieldOfView;
        // The verticall FOV is the same because the camera fixed height
        float multiplier = (horizontalDesignFOV / cameraHorizontalFOV) / 2;
        // Multiplies the the vertical camera FOV into the vertical design FOV

        cam.fieldOfView *= multiplier;
        // Apply the multiplier
    }
}
