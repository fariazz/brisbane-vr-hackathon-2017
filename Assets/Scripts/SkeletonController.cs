using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

[RequireComponent(typeof(VRInteractiveItem))]
public class SkeletonController : MonoBehaviour {

    public float speed = 0.2f;

    VRInteractiveItem vrInteractive;

    bool isAttacking = false;
    
    void Awake()
    {
        //get the component
        vrInteractive = GetComponent<VRInteractiveItem>();

        transform.LookAt(Camera.main.transform.position);
    }

    void OnEnable()
    {
        vrInteractive.OnClick += () => { isAttacking = true; };
    }

    void OnDisable()
    {
        vrInteractive.OnClick -= () => { isAttacking = true; };
    }

    // Update is called once per frame
    void Update () {
        if (!isAttacking) return;

        // calculate the distance from target
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        // have we arrived?
        if (distance > 0)
        {
            // calculate how much we need to move (step) d = v * t
            float step = speed * Time.deltaTime;

            // move by that step
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, step);
        }
    }
}
