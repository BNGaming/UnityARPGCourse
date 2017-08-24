using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArmFollowSimpleRotate : MonoBehaviour {

    GameObject player;
    public float rotationAngle;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position;
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationAngle);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationAngle);
        }
    }
}
