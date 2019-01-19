using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShark : MonoBehaviour {

    public float SharkSpeed;
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(transform.position.x + SharkSpeed * Time.deltaTime, transform.position.y, transform.position.z);
	}
}
