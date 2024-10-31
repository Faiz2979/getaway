using UnityEngine;

public class RandomTextGenerator : MonoBehaviour
{
    // Daftar karakter yang akan diacak
    private string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890.";
    public string randomString;
    

    // Fungsi untuk membuat susunan acak dari karakter
    public string GenerateRandomText()
    {
        string randomText = "";
        for (int i = 0; i < 8; i++)
        {
            int randomIndex = Random.Range(0, characters.Length);
            randomText += characters[randomIndex];
        }
        return randomText;
    }

    public void GenerateText()
    {
        randomString = GenerateRandomText();
        Debug.Log("Random string: " + randomString);
    }
}
