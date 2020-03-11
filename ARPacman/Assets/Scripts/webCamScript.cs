using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamScript : MonoBehaviour
{
    public GameObject webCameraPlane;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = transform.position;
            transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90f);
        }
        Input.gyro.enabled = true;
        WebCamTexture webCamTexture = new WebCamTexture();
        webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCamTexture;
        webCamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("\r\n\r\n\r\n\r\n\r\n");
        Debug.Log($"gyro: {Input.gyro.attitude.eulerAngles.ToString()}");
        Debug.Log("\r\n\r\n\r\n\r\n\r\n");
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        transform.localRotation = cameraRotation;
    }
}
