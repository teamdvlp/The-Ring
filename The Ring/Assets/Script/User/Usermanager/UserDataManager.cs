using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class UserDataManager
{
    public const string FolderUserData = "userData.dat";

    public UserDataManager()
    {

    }

    public bool saveUser()
    {
        try
        {
            Debug.Log("SAVE USER ");
            User user = User.getInstance();
            Debug.Log("COUNT WHEN SAVE : " + user.Characters.Count);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Create(Application.persistentDataPath + "/" + FolderUserData);
            bf.Serialize(fileStream, user);
            fileStream.Close();
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return false;
        }
    }

    public bool getUser()
    {
        try
        {
            Debug.Log("GETUSER");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.persistentDataPath + "/" + FolderUserData, FileMode.Open);
            User user = (User)bf.Deserialize(fileStream);

            User.getInstance().Characters = user.Characters != null ? user.Characters : new List<Character>();

            User.getInstance().Equipments = user.Equipments != null ? user.Equipments : new List<Equipment>();

            User.getInstance().setCurrentChacracter(user.CurrentCharacter);
            User.getInstance().setCurrentEquipment(user.CurrentEquipment);
            User.getInstance().Coin = user.Coin;
            fileStream.Close();
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return false;
        }
    }


	//public bool getUser () {
	//	try {
	//		BinaryFormatter bf = new BinaryFormatter ();
	//		if (File.Exists(Application.persistentDataPath + "/" + FolderUserData)) {
	//		FileStream fileStream = File.Open (Application.persistentDataPath + "/" + FolderUserData, FileMode.Open);
	//		User user = (User) bf.Deserialize(fileStream);
	//		User.getInstance().Equipments = user.Equipments;
	//		User.getInstance().Characters = user.Characters;
	//		User.getInstance().setCurrentChacracter(user.CurrentCharacter);
	//		User.getInstance().setCurrentEquipment(user.CurrentEquipment);
	//		User.getInstance().Coin = user.Coin;
	//		fileStream.Close();
	//		return true;
	//		}
	//		Debug.Log("File not found");
	//		return false;
	//	} catch (Exception e) {
	//		Debug.LogError(e.ToString());
	//		return false;
	//	}
	//}
}
