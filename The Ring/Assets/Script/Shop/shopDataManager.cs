using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class shopDataManager {
	public const string FolderShopData = "shopData.dat";

	public shopDataManager () {
	}

	public bool save () {
		try {
			shop mShop = shop.getInstance();
			// cách thêm dữ liệu vào cửa hàng, cứ thêm dữ liệu vào đây, lúc public game thì xóa hàm hoặc để private
			mShop.Characters = new List<Character> ();
			mShop.Equipments = new List<Equipment>();
			mShop.Characters.addItem(new Character("đường dẫn đến prefab", 1000, 10000));
			mShop.Characters.addItem (new Character("đường dẫn đến prefab",123,2333));

			mShop.Equipments.addItem(new Equipment ("đường dẫn đến prefab",12323));
			mShop.Equipments.addItem(new Equipment ("đường dẫn đến prefab",232323));
			// không đụng đến
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create(Application.dataPath + "/shop/" + FolderShopData);
			bf.Serialize(file, mShop);
			file.Close();
			return true;
		} catch (Exception e) {
			Debug.LogError(e.ToString());
			return false;
		}
	}	

	public bool getShop () {
		try {
			BinaryFormatter bf = new BinaryFormatter();
			if (File.Exists(Application.dataPath + "/shop/" + FolderShopData)) {
				FileStream file = File.Open (Application.dataPath + "/shop/" + FolderShopData, FileMode.Open);
				shop mShop = (shop) bf.Deserialize(file);

				shop.getInstance().Characters = mShop.Characters;
				shop.getInstance().Equipments = mShop.Equipments;
				return true;
			}
				Debug.LogError ("Không tìm thấy file");
				return false;
		} catch (Exception e) {
			Debug.LogError(e.ToString());
			return false;
		}
	}
}

public static class ExtenMethodListCharacter {
	public static void addItem (this List<Character> list, Character item) {
		item.setId(list.Count);
		list.Add(item);
	} 
}
public static class ExtenMethodListEquipment {
	public static void addItem (this List<Equipment> list, Equipment item) {
		item.setId(list.Count);
		list.Add(item);
	}
}