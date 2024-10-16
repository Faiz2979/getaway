using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpDummy : MonoBehaviour
{
public string skillName;  // Nama skill
    public PlayerStats playerStats;  // Referensi ke PlayerStats
    public int experience = 30;  // Jumlah XP yang akan ditambahkan

    // Metode untuk menambahkan XP
    public void addExp()
    {
        // Tambahkan XP ke skill berdasarkan nama
        playerStats.AddSkillExperience(skillName, experience);
    }
}
