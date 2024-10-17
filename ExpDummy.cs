using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpDummy : MonoBehaviour
{

    public PlayerStats playerStats;  // Referensi ke PlayerStats
    public int experience = 30;  // Jumlah XP yang akan ditambahkan
    public bool expAlreadyTaken = false;  // Menandai apakah XP sudah diambil

    // Metode untuk menambahkan XP ke skill
    public void addExp()
    {
        if (!expAlreadyTaken)
        {
            playerStats.AddWebSecurityXp(experience);  // Menambahkan XP ke skill
            expAlreadyTaken = true;  // Menandai bahwa XP sudah diambil
        }
    }
}
