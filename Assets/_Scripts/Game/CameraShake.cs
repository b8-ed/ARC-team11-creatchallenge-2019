using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    private float shakeDuration = 0f;

    private float shakeMagnitude = 0.1f;

    private float dampingSpeed = 1.0f;

    Vector3 initialPosition;


    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    public void TriggerShake()
    {
        shakeDuration = 0.4f;
        initialPosition = transform.localPosition;

    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = new Vector3(initialPosition.x, transform.position.y, initialPosition.z) + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
        }
    }
}
