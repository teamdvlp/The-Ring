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
=======
	    this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * speed;
        //trackpad.positionOffset = Vector2.zero;
>>>>>>> 0313a1d5f02ecd5eafd64be34a6507b952eab788
	}

    void LimitMovement ()
    {
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, playerLimits.MinimumX, playerLimits.MaximumX), Mathf.Clamp(this.transform.position.y,playerLimits.MinimumY,playerLimits.MaximumY), this.transform.position.z);
    }
}
