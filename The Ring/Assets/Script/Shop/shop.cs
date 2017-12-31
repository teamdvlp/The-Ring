using System.Collections.Generic;
using System;
[Serializable]
public class shop {
	private static shop instance;
	public List<Equipment> Equipments;
	public List <Character> Characters; 
	private shop () {}
	public static shop getInstance () {
		if (instance == null) {
			instance = new shop();
		}
		return shop.instance;
	}
} 
