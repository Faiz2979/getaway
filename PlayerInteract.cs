using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    private PlayerController py;  // Referensi ke PlayerController
    private Door door;  // Referensi ke Door

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
    }

    // Metode untuk interaksi pemain
    public void Interact()
    {
        if (py.canInteract)
        {
            Debug.Log("Player Can Interact");
        }

        // Cek apakah interaksi dengan pintu bisa memicu perubahan scene
        if (ChangeSceneDoorInteract())
        {
            door.ChangeScene();  // Memanggil metode pada Door untuk berpindah scene
        }
    }

    // Mengambil komponen Door dari objek pintu yang berinteraksi dengan player
    void OnTriggerEnter2D(Collider2D other)
    {
        py.canInteract = true;

        if (other.CompareTag("Door"))
        {
            door = other.GetComponent<Door>();  // Mengambil komponen Door dari objek pintu
        }
        if (other.CompareTag("Desk"))
        {
            py.onDesk = true;
            Debug.Log("Player in the desk");
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

    // Cek apakah player bisa mengubah scene melalui interaksi dengan pintu
    bool ChangeSceneDoorInteract()
    {
        // Hanya bisa berubah scene jika ada interaksi dan ada tujuan scene yang diatur pada door
        return py.interact && door != null && door.sceneDestination != null;
    }
}
