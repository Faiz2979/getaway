using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    private PlayerController py;  // Referensiz ke PlayerController
    private GameObject door;  // Referensi ke Door
    private ExpDummy exp;  // Referensi ke ExpDummy
    bool expAlreadyTaken = false;

    void Start()
    {
        py = GetComponent<PlayerController>();  // Mendapatkan komponen PlayerController
    }

    void Update()
    {
        // Kondisi untuk mengecek apakah player berada di depan komputer
        py.onComputer = py.canInteract && py.interact && py.onDesk;
        if (py.onDesk && py.onComputer)
        {
            Debug.Log("Player is on the computer");
            SceneManager.LoadScene("onComputer");  // Memuat scene untuk komputer
        }
        if (py.interact && exp != null && !expAlreadyTaken)
        {
            Debug.Log("Player take the exp");
            exp.addExp();
            Debug.Log("Player has take the exp");
            expAlreadyTaken = true;
        }
    }

    // Metode untuk interaksi pemain
    public void Interact()
    {
        if (py.canInteract)
        {
            Debug.Log("Player Can Interact");
        }
        if (door != null && py.canInteract && py.interact)
        {

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        py.canInteract = true;
        // Mengambil komponen Door dari objek pintu yang berinteraksi dengan player
        if (other.CompareTag("Door"))
        {
            door = other.gameObject;  // Mengambil komponen Door dari objek pintu
        }
        if (other.CompareTag("Desk"))
        {
            py.onDesk = true;
            Debug.Log("Player in the desk");
        }
        if(other.CompareTag("ExpDummy"))
        {
            exp = other.GetComponent<ExpDummy>();
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        py.canInteract = false;

        if (other.CompareTag("Door"))
        {
            door = null;  // Mengosongkan referensi door ketika keluar dari area pintu
        }
        if (other.CompareTag("Desk"))
        {
            py.onDesk = false;
            Debug.Log("Player not in the desk");
        }
    }
    
}
