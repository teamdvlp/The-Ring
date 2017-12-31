using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class UserDataManager {
	public const string FolderUserData = "userData.dat";	
	public UserDataManager () {
		File.Delete(Application.persistentDataPath + "/" + FolderUserData);
	}

	public bool saveUser () {
		try {
			User user = User.getInstance();
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fileStream =	File.Create(Application.persistentDataPath + "/" + FolderUserData);
			bf.Serialize(fileStream, user);		
			fileStream.Close();
			return true;
		} catch (Exception e) {
			Debug.LogError(e.ToString());
			return false;
		}
	}

	public bool getUser () {
		try {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fileStream = File.Open (Application.persistentDataPath + "/" + FolderUserData, FileMode.Open);
			User user = (User) bf.Deserialize(fileStream);
			User.getInstance().setCurrentChacracter(user.CurrentCharacter);
			User.getInstance().setCurrentEquipment(user.CurrentEquipment);
			User.getInstance().Coin = user.Coin;
			User.getInstance().Equipments = user.Equipments;
			User.getInstance().Characters = user.Characters;
			fileStream.Close();
			return true;
		} catch (Exception e) {
			Debug.LogError(e.ToString());
			return false;
		}
		
	}
}
