using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {
    public float startSpeed;
    Rigidbody2D rigid2D;
    public float maintainSpeed;


	// Use this for initialization
	void Start () {
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.angularVelocity = startSpeed;
	}

}
