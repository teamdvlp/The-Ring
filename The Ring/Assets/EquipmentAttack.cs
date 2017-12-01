using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentAttack : MonoBehaviour {
	public int speed;
	public GameObject par;
	void Start () {
		GetComponent<Rigidbody2D>().angularVelocity = speed;
	}

	void OnCollisionStay2D(Collision2D other)
	{
		GameObject obj = Instantiate(par);
		float aliveTime = obj.GetComponent<ParticleSystem>().startLifetime;
		obj.GetComponent<AutoDestroy>().destroyTime = aliveTime;
		obj.transform.position = other.contacts[0].point;
	}	
}
