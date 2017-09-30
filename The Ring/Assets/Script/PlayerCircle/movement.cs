using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public Trackpad trackpad;
    public int speed;
    public Limit playerLimits;

    void Start () {
		
	}
	void Update () {

        this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * speed ;
        trackpad.positionOffset = Vector2.zero;
	    //this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * speed;
<<<<<<< HEAD
        //this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * speed ;
        //trackpad.positionOffset = Vector2.zero;
=======
=======
        this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * speed ;
        trackpad.positionOffset = Vector2.zero;
<<<<<<< HEAD
=======
>>>>>>> 8881d1154d32b1dc997961c9c32314f0dc521f5a
>>>>>>> 4da369b5c11811d4a605f2f77e5dfb6f04c0c1b2
        //trackpad.positionOffset = Vector2.zero;
>>>>>>> 3fa9cb2ab1fd7de7ef56e9925936bf80b19e9d03
	}

    void LimitMovement ()
    {
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, playerLimits.MinimumX, playerLimits.MaximumX), Mathf.Clamp(this.transform.position.y,playerLimits.MinimumY,playerLimits.MaximumY), this.transform.position.z);
    }
}
