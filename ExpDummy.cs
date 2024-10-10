using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpDummy : MonoBehaviour
{
    public Skill skill;
    public PlayerStats playerStats;
    public int experience=30;

    public void addExp()
    {
        playerStats.AddSkillExperience(skill, experience);
    }
}
