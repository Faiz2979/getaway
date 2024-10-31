using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator anim;
    public bool isTransitioning = false;
    public string sceneToChangeTo;
    public float delay;
        public void Mulai(){
        StartCoroutine(ChangeSceneCoroutine());
        }

    public IEnumerator ChangeSceneCoroutine()
    {
        if(anim != null)
        {
            // Jika transisi sudah berjalan, jangan mulai lagi
            if (isTransitioning)
            {
                yield break; // Exit coroutine if transition is already in progress
            }

            isTransitioning = true; // Start transition
            anim.SetBool("isTransitioning", isTransitioning);
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(sceneToChangeTo);

            isTransitioning = false; // Transition finished
        }
        else
        {
            SceneManager.LoadScene(sceneToChangeTo);
        }
    }

        public void Keluar(){
        Application.Quit();
    }
}
