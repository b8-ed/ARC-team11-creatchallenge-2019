using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float CameraSpeed;

    private Camera mainCamera;

	void Start ()
    {
        mainCamera = GetComponent<Camera>();
	}

    void Update()
    {
        if (GameManager.Instance.isGameRunning)
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, 
                                                        mainCamera.transform.position.y + Time.deltaTime * CameraSpeed, 
                                                        mainCamera.transform.position.z);
	}
}
