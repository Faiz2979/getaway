using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class MinigameController : MonoBehaviour
{
    [SerializeField] GameObject passwordCracker;
    [SerializeField] TextMeshProUGUI PWanswer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PasswordCrackerMinigame()
    {
        passwordCracker.SetActive(true);
        RandomTextGenerator pw = GetComponent<RandomTextGenerator>();
        pw.GenerateText();
        PWanswer.text = pw.randomString;

    }
}
