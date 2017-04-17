using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZTesApha {
    public class AphaGroup : MonoBehaviour {

        private List<ZTesApha> nodes;

        // Use this for initialization
        void Awake() {
            nodes = new List<ZTesApha>(GetComponentsInChildren<ZTesApha>());
        }

        public void detecte() {
            nodes.ForEach(n => {
                n._detecte();
            });
        }

    }
}
