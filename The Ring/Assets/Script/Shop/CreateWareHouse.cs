using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWareHouse : MonoBehaviour {
	public List<Sprite> CharacterSprites;

	void Start () {
		Warehouse.newInstance(CharacterSprites);
	}

}
