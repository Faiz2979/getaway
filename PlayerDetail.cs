using UnityEngine;

public class PlayerDetail : MonoBehaviour {
    public PlayerStats playerStats; // Make sure to link PlayerStats from the inspector
    public int Stress;
    public int Reputation;
    public int Money;
    public Vector3 Position;
    public Vector3 CamPos;
    public Skill WebSecurity;
    public Skill Forensics;
    public Skill SocialEngineering;
    public Skill Cryptography;
    public Skill ReverseEngineering;

    // Function to save player data
    public void SavePlayer() {
        PlayerStatsUpdate(); // Update playerStats before saving
        SaveSystem.SavePlayer(playerStats);
        Debug.Log("Game has been saved.");
    }
    public void ResetSkillData() {
        playerStats.WebSecurity.ResetAllData();
        playerStats.Forensics.ResetAllData();
        playerStats.SocialEngineering.ResetAllData();
        playerStats.Cryptography.ResetAllData();
        playerStats.ReverseEngineering.ResetAllData();
        
    }

    // Function to update PlayerStats values with local values
    void PlayerStatsUpdate() {
        playerStats.Money = Money;
        playerStats.Stress = Stress;
        playerStats.Reputation = Reputation;

        playerStats.Position = transform.position;
        playerStats.CamPos = Camera.main.transform.position;
        
        playerStats.WebSecurity = WebSecurity;
        playerStats.Forensics = Forensics;
        playerStats.SocialEngineering = SocialEngineering;
        playerStats.Cryptography = Cryptography;
        playerStats.ReverseEngineering = ReverseEngineering;
    }

    // Function to load player data
    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer(); // Load data from SaveSystem
    if (data != null) {
            Stress = data.Stress; // Fill data from saved file
            Reputation = data.Reputation;
            Money = data.Money;

            Position = new Vector3(data.position[0], data.position[1], data.position[2]);
            CamPos = new Vector3(data.camPos[0], data.camPos[1], data.camPos[2]);
            transform.position = Position; // Set object position
            Camera.main.transform.position = CamPos;
            
            playerStats.WebSecurity.SetData(data.WebSecurity);
            playerStats.Forensics.SetData(data.Forensics);
            playerStats.SocialEngineering.SetData(data.SocialEngineering);
            playerStats.Cryptography.SetData(data.Cryptography);
            playerStats.ReverseEngineering.SetData(data.ReverseEngineering);

        Debug.Log("Game has been loaded.");
            PlayerInfo(); // Display player information after load
    } else {
        Debug.LogError("No save file found.");
    }
    }

    // Function to display player information in the console
    public void PlayerInfo() {
        Debug.Log("Player Stats:");
        Debug.Log("Money: " + Money);
        Debug.Log("Reputation: " + Reputation);
        Debug.Log("Stress: " + Stress);
        Debug.Log("Position: " + Position);
    }

    // Start is called when the game starts
    void Start() {
        LoadPlayer(); // Load player data when the game starts
        PlayerInfo(); // Display player information when the game starts
    }
    void OnApplicationQuit()
    {
        SavePlayer(); // Save player data when the game is closed
    }
}
