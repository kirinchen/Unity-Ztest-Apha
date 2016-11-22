using UnityEngine;
using System.Collections;

namespace ZTesApha {
    public class TestMove : MonoBehaviour {

        // Update is called once per frame
        void Update() {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(x,y,0));
        }
    }
}
