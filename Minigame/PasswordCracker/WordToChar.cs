using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Recorder;

public class WordToChar : MonoBehaviour
{
    // string dari RandomTextGenerator akan dijadikan char dan charNumber akan menunjukkan urutan char tersebut
    private char currentChar;
    public MinigameReward reward;

    [SerializeField] int charNumber;
    [SerializeField] string word;
    [SerializeField] string[] charwords;
    [SerializeField] private RandomTextGenerator TextAnswer;
    [SerializeField]Image[] charContainer;
    [SerializeField]TextMeshProUGUI[] charItem;
    [SerializeField]Image Normal;
    [SerializeField]Image Correct;
    [SerializeField]Image Incorrect;
    [SerializeField]Image WrongPosition;
    public TMP_InputField input1;
    private int experience = 100;

    public void Start()
    {
        TextAnswer.handleWord();
        word = TextAnswer.GetRandomText().ToUpper();
        charwords = word.ToCharArray().Select(c => c.ToString()).ToArray();


        if (!string.IsNullOrEmpty(word) && charNumber >= 0 && charNumber < word.Length)
        {
            currentChar = word[charNumber];
        }
        else
        {
            Debug.LogError("Invalid word or charNumber");
        }


    }

    // Update is called once per frame
    void Update()
{
    // Update the input preview in real-time
    UpdateInputPreview(input1.text);

    // Check if the Enter key is pressed to evaluate the answer

}

// Method to update the input preview
void UpdateInputPreview(string input)
{
    char[] inputChars = input.ToCharArray();

    // Loop through the characters in the input and update the charItem array
    for (int i = 0; i < charItem.Length; i++)
    {
        if (i < inputChars.Length)
        {
            charItem[i].text = inputChars[i].ToString(); // Show the character
        }
        else
        {
            charItem[i].text = ""; // Clear any extra characters
        }
    }
}

// Method to check the player's input when Enter is pressed
public void InputtoChar()
{
    char[] inputChars = input1.text.ToUpper().ToCharArray();
    List<bool> matchedFlags = new List<bool>(new bool[charwords.Length]);
    int correctCount = 0; // Counter for correctly guessed characters

    // Ensure the arrays are of equal length to avoid index out-of-range errors
    if (inputChars.Length != charwords.Length)
    {
        Debug.LogError("Input length does not match the word length.");
        return;
    }

    // Reset all images to Normal before updating
    for (int i = 0; i < charContainer.Length; i++)
    {
        charContainer[i].sprite = Normal.sprite;
    }

    // First pass: Check for characters that are in the correct position
    for (int i = 0; i < inputChars.Length; i++)
    {
        Debug.Log($"inputChars[{i}]: {inputChars[i]}, charwords[{i}]: {charwords[i]}");

        if (inputChars[i] == charwords[i][0]) // Correct position
        {
            charContainer[i].sprite = Correct.sprite;
            matchedFlags[i] = true; // Mark as matched
            correctCount++; // Increment correct count
            Debug.Log("Correct");
        }
    }

    // Second pass: Check for characters that are in the wrong position
    for (int i = 0; i < inputChars.Length; i++)
    {
        if (charContainer[i].sprite == Correct.sprite) continue; // Skip already matched characters

        bool foundWrongPosition = false;
        for (int j = 0; j < charwords.Length; j++)
        {
            // Check if the character matches, is not in the correct position, and has not been marked
            if (inputChars[i] == charwords[j][0] && !matchedFlags[j])
            {
                charContainer[i].sprite = WrongPosition.sprite; // Set to Wrong Position sprite
                matchedFlags[j] = true; // Mark this character as matched
                foundWrongPosition = true;
                Debug.Log("Wrong Position");
                break; // Stop searching after finding the first match
            }
        }

        if (!foundWrongPosition)
        {
            charContainer[i].sprite = Incorrect.sprite; // Set to Incorrect sprite if no match found
            Debug.Log("Incorrect");
        }
    }

    // Check if all characters are correctly guessed
    if (correctCount == charwords.Length)
    {
        reward.RewardPWCracker(experience); // Call the reward function
        GameEnded(); // Call the game ended function
    }
}

// Reward function to be called when all characters are correct
    void GameEnded()
    {
        ResetGame();
        gameObject.SetActive(false);
        Debug.Log("Game Ended");
    }
    public void ResetGame(){
    // Reset the input field
    input1.text = "";

    // Reset charContainer sprites to Normal
    for (int i = 0; i < charContainer.Length; i++)
    {
        charContainer[i].sprite = Normal.sprite;
        charItem[i].text = ""; // Clear any character display
    }

    // Generate a new random word
    word = TextAnswer.GetRandomText().ToUpper();
    charwords = word.ToCharArray().Select(c => c.ToString()).ToArray();

    // Reset any other necessary variables
    charNumber = 0;
}
    public void QuitGame()
    {
        GameEnded();
    }
}
