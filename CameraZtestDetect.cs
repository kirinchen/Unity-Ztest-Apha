using UnityEngine;
using System.Collections;
using System;

namespace ZTesApha {
    public class CameraZtestDetect : MonoBehaviour {

        private Camera cmr;
        // Use this for initialization
        void Start() {
            cmr = GetComponent<Camera>();
            InvokeRepeating("cast", 2.0f, 0.3f);
        }

        void cast() {
            Vector3 fwd = cmr.transform.TransformDirection(Vector3.forward);

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, fwd, out hit, 100f)) {
                ZTesApha mr = hit.collider.GetComponent<ZTesApha>();
                if (mr != null) {
                    mr.detecte();

                }
            }



        }
    }
}
