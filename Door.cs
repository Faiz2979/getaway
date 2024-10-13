using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform destination;
    public Transform cameraPosition;
    public Animator anim;
    public Transform GetDestination()
    {
        
        return destination;
    }

    public Transform GetCameraPosition()
    {
        return cameraPosition;
    }
}
