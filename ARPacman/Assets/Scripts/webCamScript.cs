using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webCamScript : MonoBehaviour
{
    public GameObject webCameraPlane;

    private LocationInfo previousLocationInfo;

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
        Input.location.Start(0.00001f, 0.01f);
        if (Input.location.status == LocationServiceStatus.Running)
        {
            previousLocationInfo = new LocationInfo();
            previousLocationInfo = Input.location.lastData;
        }
        WebCamTexture webCamTexture = new WebCamTexture();
        webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCamTexture;
        webCamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
        if (Application.isMobilePlatform && Input.location.status == LocationServiceStatus.Running)
        {
            Debug.Log($"ARPACMAN: location service running:{(Input.location.status == LocationServiceStatus.Running ? "true" : "false")}");
            transform.Translate(new Vector3(previousLocationInfo.longitude - Input.location.lastData.longitude, 0, previousLocationInfo.latitude - Input.location.lastData.latitude));
            Debug.Log($"ARPACMAN: previous longitude: {previousLocationInfo.longitude}, latitude: {previousLocationInfo.latitude}\r\n" +
                $"current longitude {Input.location.lastData.longitude}, latitude: {Input.location.lastData.latitude}");
            previousLocationInfo = Input.location.lastData;
        }
        Debug.Log("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        transform.localRotation = cameraRotation;
    }
}
