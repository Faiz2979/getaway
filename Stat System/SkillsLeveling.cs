using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsLeveling : MonoBehaviour
{
    public PlayerStats playerStats;  // Referensi ke PlayerStats
    public int experience = 30;  // Jumlah XP yang akan ditambahkan
    
    public bool expAlreadyTaken = false;  // Menandai apakah XP sudah diambil
    public Animator anim; //memulai animasi belajar saat belajar skill
    
    

    // Metode untuk menambahkan XP ke skill
    public void addExp()
    {
        if (!expAlreadyTaken)
        {
            playerStats.AddWebSecurityXp(experience);  // Menambahkan XP ke skill
            expAlreadyTaken = true;  // Menandai bahwa XP sudah diambil
        }
    }

    public void LearnWebSecurity(){
        playerStats.WebSecurity.AddExperience(experience);
    }
    public void LearnForensics(){
        playerStats.Forensics.AddExperience(experience);
    }
    public void LearnSocialEngineering(){
        playerStats.SocialEngineering.AddExperience(experience);
    }
    public void LearnCryptography(){
        playerStats.Cryptography.AddExperience(experience);
    }
    public void LearnReverseEngineering(){
        playerStats.ReverseEngineering.AddExperience(experience);
    }

}
