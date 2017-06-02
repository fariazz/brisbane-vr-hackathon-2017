using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

namespace ZenvaVR
{

    [RequireComponent(typeof(VRInteractiveItem))]
    public class VRCalloutController : MonoBehaviour
    {

        // canvas that will be shown/hidden
        public Canvas canvas;

        // is it showing by default?
        public bool isInitiallyVisible = false;

        // activate when hovering the reticle over?
        public bool isHoverActivated = false;

        // activate when clicking?
        public bool isClickActivated = false;

        // vr interactive item component
        VRInteractiveItem vrInteractive;

        void Awake()
        {
            //get the component
            vrInteractive = GetComponent<VRInteractiveItem>();

            //is it initially visible
            canvas.enabled = isInitiallyVisible;
        }

        void OnEnable()
        {
            //hook on to hovering events
            if (isHoverActivated)
            {
                vrInteractive.OnOver += ShowCanvas;
                vrInteractive.OnOut += HideCanvas;
            }

            //hook on to the click event
            if (isClickActivated)
            {
                vrInteractive.OnClick += ToggleCanvas;
            }
        }

        void OnDisable()
        {
            //remove hook for hovering events
            if (isHoverActivated)
            {
                vrInteractive.OnOver -= ShowCanvas;
                vrInteractive.OnOut -= HideCanvas;
            }

            //remove hook for the click event
            if (isClickActivated)
            {
                vrInteractive.OnClick -= ToggleCanvas;
            }
        }

        void ToggleCanvas()
        {
            canvas.enabled = !canvas.enabled;
        }

        private void HideCanvas()
        {
            canvas.enabled = false;
        }

        private void ShowCanvas()
        {
            canvas.enabled = true;
        }

    }
}
