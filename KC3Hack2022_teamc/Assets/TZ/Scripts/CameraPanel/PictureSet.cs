using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TZ.Camera {
    public class PictureSet : MonoBehaviour {
        [SerializeField] GameObject panel;
        [SerializeField] PictureSave pictureSave;
        RawImage myImage;
        public void OnClick() {
            panel.SetActive(true);
            pictureSave.SetImageFlame(myImage);
        }
    }
}