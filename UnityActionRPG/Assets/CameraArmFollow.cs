using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraPositioning
{
    Cylindrical,
    Spherical,
    UseChildCamera
}

public class CameraArmFollow : MonoBehaviour {

    public CameraPositioning cameraPositioning;
    public float cylindricalRadius;
    public float cylindricalAngle;
    public float cylindricalHeight;
    public float sphericalRadius;
    public float sphericalAngle;
    public float sphericalAzimuth;

    GameObject player;
    GameObject attachedCamera;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        attachedCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position;

        if (cameraPositioning != CameraPositioning.UseChildCamera)
        {
            Vector3 CameraPosition = Vector3.zero;
            if (cameraPositioning == CameraPositioning.Cylindrical)
            {
                CameraPosition.x = cylindricalRadius * Mathf.Cos(Mathf.Deg2Rad * cylindricalAngle);
                CameraPosition.y = cylindricalHeight;
                CameraPosition.z = cylindricalRadius * Mathf.Sin(Mathf.Deg2Rad * cylindricalAngle);
            }
            else if (cameraPositioning == CameraPositioning.Spherical)
            {
                CameraPosition.x = sphericalRadius * Mathf.Sin(Mathf.Deg2Rad * sphericalAzimuth) * Mathf.Cos(Mathf.Deg2Rad * sphericalAngle);
                CameraPosition.y = sphericalRadius * Mathf.Cos(Mathf.Deg2Rad * sphericalAzimuth);
                CameraPosition.z = sphericalRadius * Mathf.Sin(Mathf.Deg2Rad * sphericalAzimuth) * Mathf.Sin(Mathf.Deg2Rad * sphericalAngle);
            }
            else if (cameraPositioning == CameraPositioning.UseChildCamera)
            {
                CameraPosition = attachedCamera.transform.position;
            }

            Quaternion CameraRotation = Quaternion.LookRotation(-CameraPosition, Vector3.up);
            attachedCamera.transform.SetPositionAndRotation(transform.position + CameraPosition, CameraRotation);
            //cylindricalAngle += 0.1f;
        }

    }
}
