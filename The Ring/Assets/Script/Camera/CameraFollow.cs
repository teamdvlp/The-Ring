using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
        public float smoothing;
        public Transform target;

    	void FixedUpdate () {
			follow();
		}

        private void follow()
        {
            if (this.target != null)
            {
			this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position
				,new Vector3(transform.position.x,target.position.y, transform.position.z)
				,this.smoothing * 0.1f);
            }
        }
}
