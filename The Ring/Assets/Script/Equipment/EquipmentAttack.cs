using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentAttack : MonoBehaviour {
	public int speed;
	public GameObject par;
	void Start () {
	}

	void OnCollisionStay2D(Collision2D other)
	{
		GameObject obj = Instantiate(par);
		float aliveTime = obj.GetComponent<ParticleSystem>().main.startLifetimeMultiplier;
		obj.GetComponent<AutoDestroy>().destroyTime = aliveTime;
		obj.transform.position = other.contacts[0].point;
	}

	void FixedUpdate()
	{
		float dt = Time.deltaTime;
		this.gameObject.transform.Rotate(0,0,speed * dt);
	}	
}
