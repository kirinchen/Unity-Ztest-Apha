using UnityEngine;
using System.Collections;
namespace ZTesApha {
    public class ZTesApha : MonoBehaviour {

        public float showTime = 1f;
        public float apha = 0.075f;
        private MeshRenderer mr;
        private bool detected;
        private float startAt;
        private Material orignalMaterial;
        public Material aphaMetial;


        void Start() {
            mr = GetComponent<MeshRenderer>();
            orignalMaterial = mr.material;
          
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
            mr.material = b ? aphaMetial : orignalMaterial;
            mr.material.mainTexture = orignalMaterial.mainTexture;
            Color c = orignalMaterial.color;
            mr.material.color = new Color(c.r, c.g, c.b, apha);
            mr.material.mainTextureOffset = orignalMaterial.mainTextureOffset;
            mr.material.mainTextureScale = orignalMaterial.mainTextureScale;
        }
    }
}
