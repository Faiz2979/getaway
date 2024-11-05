using UnityEngine;
using System.IO;

public class RandomTextGenerator : MonoBehaviour
{
    public int word;
    public string[] words;

    public void Start()
    {
    handleWord();
    GetRandomText();
    }

    public string GetRandomText()
    {
        word = Random.Range(0, words.Length);
        Debug.Log(words.Length);
        Debug.Log(word+" "+words[word]);
        // Debug.Log("Random word index: " + word + " - " + words[word]);
        if (word < 0 || word >= words.Length)
        {
            Debug.LogError("Index out of range");
            return "";
        }
        return words[word];
    }

    public void handleWord()
    {
        string filePath = Path.Combine(Application.dataPath, "Script/Minigame/PasswordCracker/5lettersWords.txt");
    words = File.ReadAllLines(filePath);

    if (words == null || words.Length == 0)
    {
        Debug.LogError("Words array is empty or not loaded correctly.");
    }
    else
    {
        Debug.Log("Words loaded successfully. Total words: " + words.Length);
    }
    }
}
