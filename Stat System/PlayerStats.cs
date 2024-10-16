using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats/Player", order = 0)]
public class PlayerStats : ScriptableObject {
    [Header("Player Stats")]
    public int Money = 0;
    public int Reputation = 0;
    public int Stress = 0;
    public Vector3 Position;
    public Vector3 CamPos;

    public Dictionary<string, Skill> skills = new Dictionary<string, Skill>();
    private void OnEnable() {
    string[] skillNames = { "Web Security", "Programming", "Forensics", "Social Engineering", "Cryptography", "Reverse Engineering" };
    
    foreach (string skillName in skillNames) {
        if (!skills.ContainsKey(skillName)) {
            skills.Add(skillName, new Skill(skillName));
        }
    }
    }
    // Method to add experience to a specific skill
    public void AddSkillExperience(string skillName, int amount) {
        if (skills.ContainsKey(skillName)) {
            skills[skillName].AddExperience(amount);
        } else {
            Debug.LogWarning("Skill not found: " + skillName);
        }
    }
}
