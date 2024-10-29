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
    public float[] camPos = new float[3];
    public PlayerData(PlayerStats playerStats) {
        Stress = playerStats.Stress;
        Reputation = playerStats.Reputation;
        Money = playerStats.Money;
        position[0] = playerStats.Position.x;
        position[1] = playerStats.Position.y;
        position[2] = playerStats.Position.z;
        camPos[0] = playerStats.CamPos.x;
        camPos[1] = playerStats.CamPos.y;
        camPos[2] = playerStats.CamPos.z;

        // Skill Data
        WebSecurity = new SkillData(playerStats.WebSecurity);
        Forensics = new SkillData(playerStats.Forensics);
        SocialEngineering = new SkillData(playerStats.SocialEngineering);
        Cryptography = new SkillData(playerStats.Cryptography);
        ReverseEngineering = new SkillData(playerStats.ReverseEngineering);
    }
}
[System.Serializable]
public class SkillData {
    public string skillName;
    public int level;
    public int experience;
    public int experienceToNextLevel;

    // Constructor to initialize SkillData from Skill
    public SkillData(Skill skill) {
        skillName = skill.skillName;
        level = skill.level;
        experience = skill.experience;
        experienceToNextLevel = skill.experienceToNextLevel;
    }

    // Method to apply data back to Skill
    public void ApplyToSkill(Skill skill) {
        skill.level = level;
        skill.experience = experience;
        skill.experienceToNextLevel = experienceToNextLevel;
    }
}
