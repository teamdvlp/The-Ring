using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
	public class User {
	private  static User instance; 	
	public List<Character> Characters;
	public Character CurrentCharacter {private set; get;}
	public Equipment CurrentEquipment {private set; get;}
	public List<Equipment> Equipments;
	public long Coin;
	private User () {
	}

	public static User getInstance() {
		if (User.instance == null) {
			User.instance = new User();
		}
			return User.instance;
	}

	public void setCurrentChacracter (Character character) {
		if (Characters.Exists(x=>x.id==character.id)) {
			this.CurrentCharacter = character;
		} else {
			Debug.Log("không thể sử dụng nhân vật chưa sở hữu");
		}
	}

	public void setCurrentEquipment (Equipment equipment) {
		if (Equipments.Exists(x=>x.id==equipment.id)) {
			this.CurrentEquipment = equipment;
		} else {
			Debug.Log("không thể sử dụng vũ khí chưa sở hữu");
		}
	}
	
}
