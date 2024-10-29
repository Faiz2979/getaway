using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public PlayerStats playerData;
    [SerializeField] string skill;
    Slider slider;
    public TextMeshProUGUI skillname;
    public TextMeshProUGUI experience;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        UpdateSkillUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkillUI();
    }

    public void SetSkill(string newSkill)
    {
        skill = newSkill;
        UpdateSkillUI();
    }

    void UpdateSkillUI()
    {
        if (playerData == null) return;

        var selectedSkill = GetSkillByName(skill);
        if (selectedSkill == null) return;
        if(selectedSkill.level == 0)
        {
            skillname.text = "Locked";
        } else{
            // Skillname
            skillname.text = selectedSkill.level+"|"+selectedSkill.skillName;
            experience.text = selectedSkill.experience.ToString() + "/" + selectedSkill.experienceToNextLevel.ToString();
            slider.maxValue = selectedSkill.experienceToNextLevel;
            slider.value = selectedSkill.experience;
        }
    }

    private Skill GetSkillByName(string skillName)
    {
        switch (skillName)
        {
            case "WebSecurity":
                return playerData.WebSecurity;
            case "Forensics":
                return playerData.Forensics;
            case "SocialEngineering":
                return playerData.SocialEngineering;
            case "Cryptography":
                return playerData.Cryptography;
            case "ReverseEngineering":
                return playerData.ReverseEngineering;
            default:
                return null;
        }
    }
}
