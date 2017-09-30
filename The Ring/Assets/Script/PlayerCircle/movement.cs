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
        //this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * speed ;
        //trackpad.positionOffset = Vector2.zero;
        //trackpad.positionOffset = Vector2.zero;
	}

    void LimitMovement ()
    {
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, playerLimits.MinimumX, playerLimits.MaximumX), Mathf.Clamp(this.transform.position.y,playerLimits.MinimumY,playerLimits.MaximumY), this.transform.position.z);
    }
}
