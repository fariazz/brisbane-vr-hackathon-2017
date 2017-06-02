using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZenvaVR
{
    public class CanvasFaceCamera : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            //get direction (pos of the canvas - pos of the camera)
            Vector3 direction = transform.position - Camera.main.transform.position;

            //set forward of the canvas
            transform.forward = direction;
        }
    }
}
