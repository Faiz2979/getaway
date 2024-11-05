using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class MinigameController : MonoBehaviour
{
    [SerializeField] GameObject passwordCracker;
    [SerializeField] GameObject cipherText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void PasswordCrackerMinigame(){
    if (passwordCracker == null)
    {
        Debug.LogError("Password Cracker GameObject is not assigned.");
        return;
    }

    passwordCracker.SetActive(true);

    // Attempt to find components
    RandomTextGenerator pw = passwordCracker.GetComponent<RandomTextGenerator>();
    WordToChar wordToChar = passwordCracker.GetComponent<WordToChar>();

    if (pw == null || wordToChar == null)
    {
        Debug.LogError("Components not found or not initialized properly.");
        return;
    }
    pw.Start();
    wordToChar.Start();
}



public void CipherTextMinigame(){
    if (cipherText == null)
    {
        Debug.LogError("Password Cracker GameObject is not assigned.");
        return;
    }

    cipherText.SetActive(true);

    // Attempt to find components
    RandomTextGenerator pw = passwordCracker.GetComponent<RandomTextGenerator>();
    CaesarCipherGame cipherGame = cipherText.GetComponent<CaesarCipherGame>();

    if (pw == null || cipherGame == null)
    {
        Debug.LogError("Components not found or not initialized properly.");
        return;
    }
    pw.Start();
    cipherGame.Start();
}
}
