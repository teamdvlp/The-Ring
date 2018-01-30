using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour {
    public MonsterMovement monsterMovement;
    public Score score;
    float time = 5f;
	
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
			monsterMovement.moveSpeed += monsterMovement.moveSpeed * score.score/ 10f;
            time = 5f;
        }
	}
}
