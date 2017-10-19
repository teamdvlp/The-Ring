using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public Trackpad trackpad;
    public float speed;
    public Limit playerLimits;

    void Start () {
		
	}
	void Update () {

        this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * speed ;
        trackpad.positionOffset = Vector2.zero;
	}

    void LimitMovement ()
    {
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, playerLimits.MinimumX, playerLimits.MaximumX), Mathf.Clamp(this.transform.position.y,playerLimits.MinimumY,playerLimits.MaximumY), this.transform.position.z);
    }
}
