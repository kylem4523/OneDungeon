using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// This class is the save system manager for the game.
// Code in this section taken from https://www.youtube.com/watch?v=XOjd_qU2Ido
public static class SaveSystem
{
	// This function serializes the players data and writes it to a file.
    public static void SavePlayer(GameObject player){
    	BinaryFormatter formatter = new BinaryFormatter();
    	string path = Application.persistentDataPath + "/player.info";
    	FileStream stream = new FileStream(path, FileMode.Create);
    	PlayerData data = new PlayerData(player);
    	formatter.Serialize(stream, data);
    	stream.Close();
    }

    // This function deserializes player data and returns an object of type PlayerData.
    public static PlayerData LoadPlayer(){
    	string path = Application.persistentDataPath + "/player.info";
    	if(File.Exists(path)){
    		BinaryFormatter formatter = new BinaryFormatter();
    		FileStream stream = new FileStream(path, FileMode.Open);
    		PlayerData data = formatter.Deserialize(stream) as PlayerData;
    		stream.Close();
    		return data;
    	}
    	else{
    		Debug.LogError("Save file not found in " + path);
    		return null;
    	}
    }
}
