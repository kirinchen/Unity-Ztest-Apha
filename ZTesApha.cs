using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace ZTesApha {
    public class ZTesApha : MonoBehaviour {

        public float showTime = 1f;
        public float apha = 0.075f;
        //private MeshRenderer mr;
        private bool detected;
        private float startAt;
        // private Material orignalMaterial;
        public bool autoInitMap = true;
        public bool applyOrgColor = true;
        public Material aphaMetial;
        public bool detectByCamera = true;
        private Dictionary<Renderer, Material> renderMap = new Dictionary<Renderer, Material>();

        void Start() {
            if (autoInitMap) {
                refleshMap();
            }
        }

        public void refleshMap() {
            renderMap.Clear();
            foreach (Renderer mr in GetComponentsInChildren<Renderer>()) {
                renderMap.Add(mr, mr.material);
            }
        }

        public void detecte() {
            startAt = Time.time;
            if (!detected) {
                StartCoroutine(cutDown());
            }
        }

        private IEnumerator cutDown() {
            setDetected(true);
            while ((Time.time - startAt) <= showTime) {
                yield return new WaitForSeconds(.1f);
            }
            setDetected(false);
        }

        private void setDetected(bool b) {
            detected = b;
            foreach (Renderer mr in renderMap.Keys) {
                if (mr != null) {
                    Material orignalMaterial = renderMap[mr];
                    mr.material = b ? aphaMetial : orignalMaterial;
                    mr.material.mainTexture = orignalMaterial.mainTexture;
                    Color c = Color.white;
                    if (applyOrgColor) {
                        c = orignalMaterial.color;
                    }
                    mr.material.color = new Color(c.r, c.g, c.b, apha);
                    mr.material.mainTextureOffset = orignalMaterial.mainTextureOffset;
                    mr.material.mainTextureScale = orignalMaterial.mainTextureScale;
                } 
            }
        }


    }
}
