using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    private GameObject FPCamera;
    private GameObject TPCamera;

    void Start()
    {
        FPCamera = GameObject.Find("Dive_Camera_FP");
        TPCamera = GameObject.Find("Dive_Camera_TP");

        TPCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            FPCamera.SetActive(false);
            TPCamera.SetActive(true);
        }
        else
        {
            TPCamera.SetActive(false);
            FPCamera.SetActive(true);
        }
    }
}
