using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Desk : MonoBehaviour
{
    PlayerController py;

    void Start()
    {
    }
    void Update()
    {
        ChangeScene();
    }
    public void ChangeScene(){
        if(py.onDesk && py.onComputer)
        {
            Debug.Log("Player is on the computer");
            SceneManager.LoadScene("onComputer");
        }
    }
}
