using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneToChangeTo;
        public void Mulai(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

    // Update is called once per frame
        public void Keluar(){
        Application.Quit();
    }
}
