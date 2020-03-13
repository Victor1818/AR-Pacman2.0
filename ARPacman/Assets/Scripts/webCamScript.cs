using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webCamScript : MonoBehaviour
{
    public GameObject webCameraPlane;

    public Gyroscope gyro;

    // Start is called before the first frame update
    void Start()
    {
        gyro = Input.gyro;
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = transform.position;
            transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90f);
        }
        gyro.enabled = true;
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
