using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;

namespace ZenvaVR
{
    [RequireComponent(typeof(VRInteractiveItem))]
    public class DestinationPinController : MonoBehaviour
    {

        //name of the scene
        public string sceneName;

        //vr interactive object component
        VRInteractiveItem vrInteractive;

        void Awake()
        {
            //grab component
            vrInteractive = GetComponent<VRInteractiveItem>();
        }

        //send the player to the specified scene
        void ChangeScene()
        {
            // loads the scene called sceneName
            SceneManager.LoadScene(sceneName);
        }

        void OnEnable()
        {
            vrInteractive.OnClick += ChangeScene;
        }

        void OnDisable()
        {
            vrInteractive.OnClick -= ChangeScene;
        }
    }
}