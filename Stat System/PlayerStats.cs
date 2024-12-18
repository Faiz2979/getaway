using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats/Player", order = 0)]
public class PlayerStats : ScriptableObject {
    [Header("Player Stats")]
    public int Money = 0;
    public int Reputation = 0;
    public int Stress = 0;
    public Vector3 Position;
    public Vector3 CamPos;

    public Skill WebSecurity = new Skill("Web Security");
    public Skill Forensics = new Skill("Forensics");
    public Skill SocialEngineering = new Skill("Social Engineering");
    public Skill Cryptography = new Skill("Cryptography");
    public Skill ReverseEngineering = new Skill("Reverse Engineering");

    // Method to add experience to a specific skill
    public void AddWebSecurityXp(int amount) {
        WebSecurity.AddExperience(amount);
    }
    public void AddCryptographyXp(int amount) {
        WebSecurity.AddExperience(amount);
    }


}
