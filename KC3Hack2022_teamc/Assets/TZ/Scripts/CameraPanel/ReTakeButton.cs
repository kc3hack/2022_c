using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TZ.Camera {
    public class ReTakeButton : MonoBehaviour {
        [SerializeField] public RawImage rawImage;
        [SerializeField] Button myButton, save;
        [SerializeField] PictureSave pictureSave;
        [SerializeField] ShotButton shotButton;
        WebCamTexture webCam;
        private void OnEnable() {
            webCam = new WebCamTexture();
            pictureSave.SetWebCam(webCam);
            shotButton.SetWebCam(webCam);
            rawImage.texture = webCam;
            webCam.requestedWidth = 1024;
            webCam.requestedHeight = 1024;
            myButton.interactable = false;
            save.interactable = false;
            CameraStart();
        }
        public void CameraStart() {
            webCam.Play();
        }
    }
}