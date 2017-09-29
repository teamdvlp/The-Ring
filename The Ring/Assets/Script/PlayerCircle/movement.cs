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
<<<<<<< HEAD

        this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * speed ;
        trackpad.positionOffset = Vector2.zero;
	    //this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * speed;
=======
        this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * speed ;
        trackpad.positionOffset = Vector2.zero;
>>>>>>> 8881d1154d32b1dc997961c9c32314f0dc521f5a
        //trackpad.positionOffset = Vector2.zero;
	}

    void LimitMovement ()
    {
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, playerLimits.MinimumX, playerLimits.MaximumX), Mathf.Clamp(this.transform.position.y,playerLimits.MinimumY,playerLimits.MaximumY), this.transform.position.z);
    }
}
