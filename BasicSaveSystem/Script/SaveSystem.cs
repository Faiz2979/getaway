using System.IO;
using UnityEngine;

public class SaveSystem
{
    // Menyimpan data pemain dan waktu ke dalam file JSON
    public static void SavePlayer(PlayerStats playerStats)
    {
        PlayerData playerData = new PlayerData(playerStats);

        // Konversi ke JSON
        string playerJson = JsonUtility.ToJson(playerData);

        // Menyimpan data ke file
        File.WriteAllText(Application.persistentDataPath + "/playerData.json", playerJson);
    }

    // Memuat data pemain dari file JSON
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            return playerData;
        }
        else
        {
            Debug.LogError("File penyimpanan tidak ditemukan di " + path);
            return null;
        }
    }
    // Memuat data waktu dari file JSON
}
