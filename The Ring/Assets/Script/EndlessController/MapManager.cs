using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	public delegate void PlayerCollisionMap (GameObject map);
	public event PlayerCollisionMap OnPlayerCollisionMap;

	public delegate void MonsterCollisionMap (GameObject map);
	public event PlayerCollisionMap OnMonsterCollisionMap;
	public EndlessManager endManager;
	void Start () {

    }
	
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
			endManager.CreateNewMap();
	}
}