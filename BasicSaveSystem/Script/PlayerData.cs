[System.Serializable]
public class PlayerData {
    public int Stress;
    public int Reputation;
    public int Money;
    public SkillData WebSecurity;
    public SkillData Programming;
    public SkillData Forensics;
    public SkillData SocialEngineering;
    public SkillData Cryptography;
    public SkillData ReverseEngineering;
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
[System.Serializable]
public class SkillData {
    public int level;
    public int experience;
    public int experienceToNextLevel;

    public SkillData(Skill skill) {
        level = skill.level;
        experience = skill.experience;
        experienceToNextLevel = skill.experienceToNextLevel;
    }
}
