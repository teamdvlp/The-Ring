using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	void Start () {
		SqliteUserManager.ClearAllCharacter();
		Debug.Log(SqliteUserManager.getCharacter()[0] + "");
	}
	
	void Update () {
		
	}
}
