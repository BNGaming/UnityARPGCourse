using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    CameraRaycaster cameraRaycaster;

	// Use this for initialization
	void Start () {
        cameraRaycaster = GetComponent<CameraRaycaster>();
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.get)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print(cameraRaycaster.layerHit);

        }
        
	}
}
