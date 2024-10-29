using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
public class DebuggingTextUI : MonoBehaviour
{
    public TextMeshProUGUI debuggingText;
    public TextMeshProUGUI debuggingText2;
    public TextMeshProUGUI debuggingText3;
    public PlayerStats playerStats;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        debuggingText.text = "Web Security Level: " + playerStats.WebSecurity.level;
        debuggingText2.text = "Web Security Experience: " + playerStats.WebSecurity.experience;
        debuggingText3.text = "Experience Requirement: " + playerStats.WebSecurity.experienceToNextLevel;
    }
}
