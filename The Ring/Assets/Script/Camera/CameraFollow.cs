using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
        public float smoothing;
        public Transform target;
        public float YLimit;
        // true: trái, false: phải
        public bool direction;

        private Vector3 offsetRight;
        private Vector3 offsetLeft;

        void Start()
        {
            this.offsetRight = new Vector3(this.transform.position.x - this.target.transform.position.x, this.transform.position.y - this.target.transform.position.y, -10);
        }
        void Update()

        {

	}

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
