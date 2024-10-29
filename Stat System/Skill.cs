using UnityEngine;

[System.Serializable]
public class Skill {
    public string skillName;
    public int level;
    public int experience;
    public int experienceToNextLevel=100;
    public int expMultiplier =0;

    // Constructor for initializing a skill
    public Skill(string name, int initialLevel = 0, int initialExp = 0, int expToNext = 100) {
        skillName = name;
        level = initialLevel;
        experience = initialExp;
        experienceToNextLevel = expToNext;

    }

    // Method to add experience and handle level up
    public void AddExperience( int amount) {

            experience += amount;
            while (experience >= experienceToNextLevel) {
                LevelUp();
            }
        
    }

    // Method for leveling up
    private void LevelUp() {
        experience -= experienceToNextLevel; // Subtract the required experience
        level++;
        experienceToNextLevel += 4 * (int)Mathf.Pow(2, level); // Increase the requirement for next level
        Debug.Log(skillName + " leveled up to level " + level + "!");
    }
    public void SetData(SkillData data) {
        level = data.level;
        experience = data.experience;
        experienceToNextLevel = data.experienceToNextLevel;
    }
    public void ResetAllData() {
        level = 0;
        experience = 0;
        experienceToNextLevel = 100;
    }
}
