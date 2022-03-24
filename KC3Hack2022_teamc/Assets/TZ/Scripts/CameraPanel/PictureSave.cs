using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
namespace TZ.Camera {
    public class PictureSave : MonoBehaviour {
        WebCamTexture webCam;
        [SerializeField] GameObject panel;
        RawImage flame;
        string setTexture;

        public void SetWebCam(WebCamTexture set) {
            webCam = set;
        }

        public void OnClick() {
            webCam.Stop();
            Texture2D texture = new Texture2D(webCam.width, webCam.height, TextureFormat.ARGB32, false);
            texture.SetPixels(webCam.GetPixels());
            texture.Apply();
            byte[] bin = texture.EncodeToJPG();
            Object.Destroy(texture);
            setTexture = Application.persistentDataPath + "/" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            File.WriteAllBytes(setTexture, bin);
            panel.SetActive(false);
        }

        public void SetImageFlame(RawImage image) {
            flame = image;
        }
    }
}