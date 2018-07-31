using UnityEngine;
using System.Collections.Generic;
//for Dictionary
using System;
//for Serializable
using System.Runtime.Serialization.Formatters.Binary;
//for file format
using System.IO;
//for file create/open/delete
public class SaveAndLoadManager : MonoBehaviour {
	public static void SavePlayer(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream strean = new FileStream (Application.persistentDataPath+"/player.sav", FileMode.Create);

		PlayerData data = new PlayerData ();
		bf.Serialize (strean, data);
		strean.Close ();
	}
//save player paramerts in file

	public static Dictionary<string, int> LoadPlayerStats(){

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream strean = new FileStream (Application.persistentDataPath + "/player.sav", FileMode.Open);

		PlayerData data = bf.Deserialize (strean)as PlayerData;

		strean.Close ();
		return data.stats;
	}
//load player parametrs
	public static void DeleteSave(){
		if(File.Exists(Application.persistentDataPath+"/player.sav")){
			File.Delete (Application.persistentDataPath + "/player.sav");
		}
	}
//delete save file
}

[Serializable]
public class PlayerData{
	public Dictionary<string, int>stats=new Dictionary<string, int>();
//create Dictionary for save and load
	public PlayerData(){
		if (MainMenuEgene.haveSave) {
			stats.Add ("Energe", PlayerStats.Energe);
			stats.Add ("EnergeMax", PlayerStats.Energemax);
			stats.Add ("Money", PlayerStats.Money);
			stats.Add ("Damager", PlayerStats.Damager);
			stats.Add ("SpeedFire", PlayerStats.SpeedFire);
			stats.Add ("Level", LevelManager.setlevel);
		} else {
			MainMenuEgene.haveSave = true;
			stats.Add ("Energe", 100);
			stats.Add ("EnergeMax", 100);
			stats.Add ("Money", 0);
			stats.Add ("Damager", 10);
			stats.Add ("SpeedFire", 0);
			stats.Add ("Level", 0);
		}
// cheack have or have not save file
//if no create with standart setup
	}

}

