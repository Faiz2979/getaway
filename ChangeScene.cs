using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneToChangeTo;
    public float delay;
        public void Mulai(){
        StartCoroutine(ChangeSceneCoroutine());
        }

    IEnumerator ChangeSceneCoroutine()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToChangeTo);
    }

    // Update is called once per frame
        public void Keluar(){
        Application.Quit();
    }
}
