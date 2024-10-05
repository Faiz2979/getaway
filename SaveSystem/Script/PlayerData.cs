[System.Serializable]
public class PlayerData {
    public int Stress;
    public int Reputation;
    public int Money;
    public float[] position = new float[3];

    public PlayerData(PlayerStats playerStats) {
        Stress = playerStats.Stress;
        Reputation = playerStats.Reputation;
        Money = playerStats.Money;
        position[0] = playerStats.Position.x;
        position[1] = playerStats.Position.y;
        position[2] = playerStats.Position.z;
    }
}
