using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour {

    Transform monsterTransform;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        monsterTransform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    void Move ()
    {
        monsterTransform.position = new Vector3(monsterTransform.position.x + moveSpeed * Time.deltaTime, monsterTransform.position.y, 0);
    }
}
