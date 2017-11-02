using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessManager : MonoBehaviour {
	public List<GameObject> map;
	private static int order;
	private static Vector2 position;
	private const int MapLength = 80;
	private int NumberOfMapHasBeenBorn;
	private float timer = 3;
	private float timerCache = 0;
	void Start () {
		timerCache = timer;
		NumberOfMapHasBeenBorn = 0;
		order = 0;
		position = Vector2.zero;
	}
	
	void Update () {
		float dt = Time.deltaTime;
		timerCache -=dt;
		if (timerCache <= 0) {
			timerCache = timer;
			createNewMap();
		}
	}

	public void createNewMap () {
		NumberOfMapHasBeenBorn ++;
		GameObject map = this.map[order];
		updatePosition();
		map = Instantiate(map);
		map.transform.position = position;
		updateMapLocation();
	}

	private void OnMapStartDestroy () {
	}

	private void updatePosition () {
		if (order < map.Count - 1) {
			order++;
		} else {
			order = 0;
		}
	}

	private void updateMapLocation () {
		position = new Vector2(0,MapLength * NumberOfMapHasBeenBorn ) ;
	}
}
