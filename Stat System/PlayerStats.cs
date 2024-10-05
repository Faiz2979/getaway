using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats/Player", order = 0)]
public class PlayerStats : ScriptableObject {
    [Header("Player Stats")]
    public int Money = 0;
    public int Reputation = 0;
    public int Stress = 0;
    public Vector3 Position;
}
