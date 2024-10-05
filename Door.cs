using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // String untuk menyimpan nama scene tujuan
    public string sceneDestination;

    // Method untuk berpindah ke scene tujuan
    public void ChangeScene()
    {
        // Menggunakan SceneManager untuk memuat scene yang ditentukan
        SceneManager.LoadScene(sceneDestination);
    }
}
