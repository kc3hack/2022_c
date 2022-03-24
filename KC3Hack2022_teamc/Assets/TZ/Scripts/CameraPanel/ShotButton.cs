using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TZ.Camera {
    public class ShotButton : MonoBehaviour {
        [SerializeField] Button retake, save;
        WebCamTexture webCam;

        public void SetWebCam(WebCamTexture set) {
            webCam = set;
        }

        public void OnShot() {
            if (webCam.isPlaying) {
                webCam.Pause();
                retake.interactable = true;
                save.interactable = true;
            } else {
                webCam.Play();
                retake.interactable = false;
                save.interactable = false;
            }
        }
    }
}