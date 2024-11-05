using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameReward : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerStats playerStats;  // Referensi ke PlayerStats
    public void RewardPWCracker(int experience)
    {
        playerStats.AddWebSecurityXp(experience);  // Menambahkan XP ke skill Web Security
        playerStats.Money += 1000;  // Menambahkan uang sebesar 100
    }

    public void RewardCaesarCipher(int experience)
    {
        playerStats.AddCryptographyXp(experience);  // Menambahkan XP ke skill Cryptography
        playerStats.Money += 1000;  // Menambahkan uang sebesar 100
    }
}
