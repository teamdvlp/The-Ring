using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSmallMonster : MonoBehaviour {
	
	private Vector2 direction;
	public float Ymin;	private float timeDeltaChangeDirection = 4f;
	public float speed = 0;
	void Start () {
			randomDirection();
	}
	
	void Update () {
		float dt = Time.deltaTime;
		move();		
		AutoRandomDirection(dt);
	}

	private void changeDirection ( ) {
			direction = new Vector2(direction.x * -1, direction.y * -1); 
	}

	private void randomDirection () {
		float x = Random.Range(-100,100);
		float y = Random.Range(-100,100);
		direction = new Vector2(x, y).normalized;
	}

	private void move () {
		this.gameObject.GetComponent<Rigidbody2D>().velocity = direction * speed;
	}

	void OnCollisionEnter2D (Collision2D col) {
		changeDirection();
	}

	private void AutoRandomDirection (float dt) {
		timeDeltaChangeDirection-=dt;
		 if(timeDeltaChangeDirection<=0) {
			 randomDirection();
			timeDeltaChangeDirection = 4;
		 }
	}
}
