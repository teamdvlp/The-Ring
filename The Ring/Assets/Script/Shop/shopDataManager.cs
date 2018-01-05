using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class ShopDataManager {
    public static bool isGetShop;
	public const string FolderShopData = "shopData.dat";
    private const string CharacterFolder = "CharacterPrebs/";
    private const string EquipmentFolder = "EquipmentPrebs/";

    public ShopDataManager () {
	}

	public bool save () {
		try {
            Shop mShop = Shop.getInstance();
            // cách thêm dữ liệu vào cửa hàng, cứ thêm dữ liệu vào đây, lúc public game thì xóa hàm hoặc để private


            mShop.Characters = new List<Character> ();
			mShop.Equipments = new List<Equipment>();

<<<<<<< HEAD
			mShop.Characters.addItem(new Character(CharacterFolder + "RedPlan", 1000, 1));
			mShop.Characters.addItem(new Character(CharacterFolder + "RedPlan", 1000, 1));
			mShop.Characters.addItem(new Character(CharacterFolder + "RedPlan", 1000, 1));
			mShop.Characters.addItem(new Character(CharacterFolder + "RedPlan", 1000, 1));
			mShop.Characters.addItem(new Character(CharacterFolder + "RedPlan", 1000, 1));
            mShop.Equipments.addItem(new Equipment (EquipmentFolder + "RedMedicine", 100));
            mShop.Equipments.addItem(new Equipment (EquipmentFolder + "RedMedicine", 100));
            mShop.Equipments.addItem(new Equipment (EquipmentFolder + "RedMedicine", 100));
            mShop.Equipments.addItem(new Equipment (EquipmentFolder + "RedMedicine", 100));
            mShop.Equipments.addItem(new Equipment (EquipmentFolder + "RedMedicine", 100));


            // không đụng đến
            BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create(Application.persistentDataPath + "/" + FolderShopData);
=======
			mShop.Equipments.addItem(new Equipment ("đường dẫn đến prefab",12323));
			mShop.Equipments.addItem(new Equipment ("đường dẫn đến prefab",232323));
			// không đụng đến
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create(Application.dataPath + "/shop/" + FolderShopData);
>>>>>>> be2f18fc8d78dca9df72ba2afa1336106fec6dc6
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
<<<<<<< HEAD
			if (File.Exists(Application.persistentDataPath + "/" + FolderShopData)) {
				FileStream file = File.Open (Application.persistentDataPath + "/" + FolderShopData, FileMode.Open);
                Shop mShop = (Shop) bf.Deserialize(file);
=======
			if (File.Exists(Application.dataPath + "/shop/" + FolderShopData)) {
				FileStream file = File.Open (Application.dataPath + "/shop/" + FolderShopData, FileMode.Open);
				shop mShop = (shop) bf.Deserialize(file);
>>>>>>> be2f18fc8d78dca9df72ba2afa1336106fec6dc6

                Shop.getInstance().Characters = mShop.Characters;
                Shop.getInstance().Equipments = mShop.Equipments;
				return true;
			} else
            {
                Debug.LogError("Không tìm thấy file At ShopDataManager.cs");
            }
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