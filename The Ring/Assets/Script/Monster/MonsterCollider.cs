using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollider : MonoBehaviour {
	public delegate void MonsterColliderWithMapBorder (GameObject Map);
	public event MonsterColliderWithMapBorder OnMonsterColliderWithMapBorder;

	public delegate void MonsterCollideBackground(GameObject bg);
    public event MonsterCollideBackground OnMonsterCollideBackground;

	void Start () {
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 21) {
			if (OnMonsterColliderWithMapBorder != null) {
				OnMonsterColliderWithMapBorder(other.gameObject.transform.parent.gameObject);
			}
		}

        //19 : Background
		if (other.gameObject.layer == 19) {
            Debug.Log("SHOW ME SOEM");
            if (OnMonsterCollideBackground != null) {
                OnMonsterCollideBackground(other.gameObject);
            }
        }
	}
	
}
