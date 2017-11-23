using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {
    public float startSpeed;
    public float mainTainSpeed;
    Rigidbody2D rigid2D;
    public float maintainSpeedTime;
    float time = 0;


	// Use this for initialization
	void Start () {
        time = maintainSpeedTime;
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.AddTorque(startSpeed);
	}

    private void Update()
    {
        time -= Time.deltaTime;
        Debug.Log("TIME: " + time);
        if (time <= 0)
        {
            Debug.Log("QUAY");
            rigid2D.AddTorque(mainTainSpeed);
            time = maintainSpeedTime;
        }
    }

}
