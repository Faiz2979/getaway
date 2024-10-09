using UnityEngine;

public class PlayerDetail : MonoBehaviour {
    public PlayerStats playerStats; // Pastikan untuk menghubungkan PlayerStats dari inspector
    public int Stress;
    public int Reputation;
    public int Money;
    public Vector3 Position;
    public Skill WebSecurity;
    public Skill Programming;
    public Skill Forensics;
    public Skill SocialEngineering;
    public Skill Cryptography;
    public Skill ReverseEngineering;

    // Fungsi untuk menyimpan data player
    public void SavePlayer() {
        PlayerInfoUpdate(); // Perbarui playerStats sebelum menyimpan
        SaveSystem.SavePlayer(playerStats);
        Debug.Log("Game has been saved.");
    }

    // Fungsi untuk memperbarui nilai PlayerStats dengan nilai lokal
    void PlayerInfoUpdate() {
        playerStats.Money = Money;
        playerStats.Stress = Stress;
        playerStats.Reputation = Reputation;
        playerStats.Position = transform.position;
        playerStats.WebSecurity = WebSecurity;
        playerStats.Programming = Programming;
        playerStats.Forensics = Forensics;
        playerStats.SocialEngineering = SocialEngineering;
        playerStats.Cryptography = Cryptography;
        playerStats.ReverseEngineering = ReverseEngineering;
    }

    // Fungsi untuk memuat data player
    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer(); // Memuat data dari SaveSystem
        if (data != null) {
            Stress = (int)data.Stress; // Mengisi data dari file yang disimpan
            Reputation = (int)data.Reputation;
            Money = data.Money;
            Position = new Vector3(data.position[0], data.position[1], data.position[2]);
            transform.position = Position; // Set posisi object
            playerStats.WebSecurity.SetData(data.WebSecurity);
            playerStats.Programming.SetData(data.Programming);
            playerStats.Forensics.SetData(data.Forensics);
            playerStats.SocialEngineering.SetData(data.SocialEngineering);
            playerStats.Cryptography.SetData(data.Cryptography);
            playerStats.ReverseEngineering.SetData(data.ReverseEngineering);

            Debug.Log("Game has been loaded.");
            PlayerInfo(); // Tampilkan informasi player setelah load
        } else {
            Debug.LogError("No save file found.");
        }
    }

    // Fungsi untuk menampilkan informasi player di konsol
    public void PlayerInfo() {
        Debug.Log("Player Stats:");
        Debug.Log("Money: " + Money);
        Debug.Log("Reputation: " + Reputation);
        Debug.Log("Stress: " + Stress);
        Debug.Log("Position: " + Position);
    }

    // Start dipanggil saat game dimulai
    void Start() {
        LoadPlayer(); // Memuat data player saat game dimulai
        PlayerInfo(); // Menampilkan informasi player saat game dimulai
    }
}
