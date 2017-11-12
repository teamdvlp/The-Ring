using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollider : MonoBehaviour {
	public delegate void MonsterColliderWithMapBorder (GameObject Map);
	public event MonsterColliderWithMapBorder OnMonsterColliderWithMapBorder;
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 21) {
				OnMonsterColliderWithMapBorder(other.gameObject.transform.parent.gameObject);
		}
	}
}
