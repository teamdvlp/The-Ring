using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRecycle : MonoBehaviour {
	MapManager mapManager;
	void Start () {
		mapManager.OnPlayerCollisionMap += OnPlayerCollisionMap;
		mapManager.OnMonsterCollisionMap += OnMonsterCollisionMap;
	}
	
	void Update () {
		
	}

	private void OnMonsterCollisionMap (GameObject map) {
		Destroy(map);
	}

	private void OnPlayerCollisionMap (GameObject map) {
		
	}

}
