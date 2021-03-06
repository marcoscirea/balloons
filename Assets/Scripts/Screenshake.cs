﻿using UnityEngine;
using System.Collections;

public class Screenshake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;
    
    // How long the object should shake for.
    public float shake = 0f;
    
    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    
    Vector3 originalPos;

    MeshRenderer red;
    
    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }

        red = GameObject.Find("Red").GetComponent<MeshRenderer>();
    }
    
    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }
    
    void Update()
    {
        if (shake > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            
            shake -= Time.deltaTime * decreaseFactor;

            //if (((int) shake*100) %2 ==0)
                red.enabled=true;
            //else
                //red.enabled=false;
        }
        else
        {
            shake = 0f;
            camTransform.localPosition = originalPos;

            GameObject.Find("Head").GetComponent<SpriteRenderer>().enabled=false;

            red.enabled=false;
        }
    }
}