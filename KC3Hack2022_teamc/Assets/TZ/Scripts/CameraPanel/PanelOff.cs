using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ.Camera {
    public class PanelOff : MonoBehaviour {
        [SerializeField] GameObject panel;

        private void Start() {
            OnClick();
        }
        public void OnClick() {
            panel.SetActive(false);
        }
    }
}