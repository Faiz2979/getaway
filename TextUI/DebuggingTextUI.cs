using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class DebuggingTextUI : MonoBehaviour
{
    public TextMeshProUGUI debuggingText;
    public PlayerStats playerStats;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        debuggingText.text = "Web Security Level: " + playerStats.WebSecurity.level;
    }
}
