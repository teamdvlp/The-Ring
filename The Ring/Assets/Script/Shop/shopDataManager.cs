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


    int buyed;


    public ShopDataManager () {
    }

	public bool save () {
            Shop mShop = Shop.getInstance();
        // cách thêm dữ liệu vào cửa hàng, cứ thêm dữ liệu vào đây, lúc public game thì xóa hàm hoặc để private


        // Reset Dữ liệu Shop trong quá trình Test, không xài thì comment lại
        //**
        //mShop.Characters = new List<Character>();
        //ResetShopData(mShop);
        //**


        BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create(Application.persistentDataPath + "/" + FolderShopData);
			bf.Serialize(file, mShop);
			file.Close();
			return true;
    }	

    private void ResetShopData (Shop mShop)
    {
        mShop.Characters.addItem(new Character(CharacterFolder + "RedPlan", 5000, 1, true, true));
        mShop.Characters.addItem(new Character(CharacterFolder + "BluePlan", 400, 1));
        mShop.Characters.addItem(new Character(CharacterFolder + "GreenPlan", 1000, 1));
        mShop.Characters.addItem(new Character(CharacterFolder + "RedPlan", 5000, 1));
        mShop.Characters.addItem(new Character(CharacterFolder + "BluePlan", 9500, 1));

    }

    public bool getShop () {
		try {
			BinaryFormatter bf = new BinaryFormatter();
			if (File.Exists(Application.persistentDataPath + "/" + FolderShopData)) {
				FileStream file = File.Open (Application.persistentDataPath + "/" + FolderShopData, FileMode.Open);
                Shop mShop = (Shop) bf.Deserialize(file);

                Shop.getInstance().Characters = mShop.Characters;
                for (int i = 0; i < Shop.getInstance().Characters.Count; i++)
                {
                    if (Shop.getInstance().Characters[i].isBought)
                    {
                        buyed++;
                    }
                }
                Debug.Log("SO LUONG NHAN VAT DA MUA " + buyed);

                    return true;
			} else
            {
                Debug.LogError("Không tìm thấy file tại ShopDataManager.cs");
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