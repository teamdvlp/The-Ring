using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newS : MonoBehaviour {
	void Start () {
		// UserDataManager ma = new UserDataManager();
		// ma.saveUser();
		// User.getInstance().Coin = 9999;
		// ma.getUser();
		// Debug.Log(User.getInstance().Coin + "   " + User.getInstance().Characters[0].path);
			shopDataManager data = new shopDataManager();
			data.save();
			data.getShop();
			Debug.Log(shop.getInstance().Characters.Count);
	}
	
	void Update () {
		
	}
}
