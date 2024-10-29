using System.Collections;
using System.Collections.Generic;
using Ink.Parsed;
using UnityEngine;
using TMPro;

public class MoreStatus : MonoBehaviour
{
    public PlayerStats playerData;
    public TextMeshProUGUI Money;
    public TextMeshProUGUI Stress;

    // Update is called once per frame
    void Update()
    {
        UpdateStatusUI();
    }

    public void UpdateStatusUI()
    {
        if (playerData == null) return;
        Money.text = "Rp "+playerData.Money.ToString();
        Stress.text = playerData.Stress.ToString() + "%";
    }
    
    void StressLimit()
    {
        if (playerData.Stress >= 100)
        {
            playerData.Stress = 100;
        }
        else if (playerData.Stress <= 0)
        {
            playerData.Stress = 0;
        }
    }
}
