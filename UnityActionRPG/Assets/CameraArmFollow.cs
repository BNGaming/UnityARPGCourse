using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArmFollow : MonoBehaviour {

    public float Radius;
    public float Angle;
    public float Height;

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

        Vector3 CameraPosition = Vector3.zero;
        CameraPosition.x = Radius * Mathf.Cos(Mathf.Deg2Rad * Angle);
        CameraPosition.y = Height;
        CameraPosition.z = Radius * Mathf.Sin(Mathf.Deg2Rad * Angle);
        Quaternion CameraRotation = Quaternion.LookRotation(-CameraPosition, Vector3.up);
        attachedCamera.transform.SetPositionAndRotation(transform.position + CameraPosition, CameraRotation);
        //Angle += 0.1f;
    }
}
