using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CaesarCipherGame : MonoBehaviour
{
    public TextMeshProUGUI cipherTextDisplay;
    public TMP_InputField answerInput;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI hintDisplay;
    public RandomTextGenerator TextGenerator;
    public int reward;

    private string originalMessage; // Pesan yang akan diacak
    private string cipheredMessage;
    private int shift; // Pergeseran acak

    public void Start()
    {
        originalMessage = TextGenerator.GetRandomText().ToUpper();
        // Menghasilkan pergeseran acak antara 1 dan 26
        shift = Random.Range(1, 27);
        hintDisplay.text = "Hint: Shift = " + shift;
        // Membuat ciphered message
        cipheredMessage = CaesarCipher(originalMessage, shift);
        cipherTextDisplay.text = "Ciphered Text: " + cipheredMessage;

    }

    // Fungsi untuk mengenkripsi teks menggunakan Caesar Cipher
    string CaesarCipher(string text, int shift)
    {
        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];
            // Menggeser huruf jika itu adalah huruf besar
            if (char.IsLetter(letter))
            {
                char d = char.IsUpper(letter) ? 'A' : 'a';
                letter = (char)((((letter + shift) - d) % 26) + d);
            }
            buffer[i] = letter;
        }
        return new string(buffer);
    }

    // Fungsi untuk memeriksa jawaban pemain
    public void CheckAnswer()
    {
        string playerAnswer = answerInput.text.ToUpper();
        if (playerAnswer == originalMessage)
        {
            resultText.text = "Correct! Great job!";
        }
        else
        {
            resultText.text = "Incorrect! Try again.";
        }
    }

    void GameEnded()
    {
        // Menambahkan reward ke MinigameReward
        MinigameReward reward = GetComponent<MinigameReward>();
        if (reward != null)
        {
            reward.RewardCaesarCipher(this.reward);
        }
    }
}
