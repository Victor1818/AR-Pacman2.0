using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webCamScript : MonoBehaviour
{
    public GameObject webCameraPlane;

    private LocationService locationService;
    LocationInfo previousLocationInfo;

    // Start is called before the first frame update
    void Start()
    {
        locationService = new LocationService();
        locationService.Start(0.1f);
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = transform.position;
            transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90f);
        }
        if(locationService.status == LocationServiceStatus.Running)
        {
            previousLocationInfo = new LocationInfo();
            previousLocationInfo = locationService.lastData;
        }
        Input.gyro.enabled = true;

        WebCamTexture webCamTexture = new WebCamTexture();
        webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCamTexture;
        webCamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(previousLocationInfo.longitude - locationService.lastData.longitude, previousLocationInfo.latitude - locationService.lastData.latitude));
        previousLocationInfo = locationService.lastData;
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        transform.localRotation = cameraRotation;
    }
}
