using System.Collections.Generic;
using System;
[Serializable]
public class Shop {
	private static Shop instance;
	public List<Equipment> Equipments;
	public List <Character> Characters; 
	private Shop() {}
	public static Shop getInstance () {
		if (instance == null) {
			instance = new Shop();
		}
		return Shop.instance;
	}
} 
