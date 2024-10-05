using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextScene(){
        
        StartCoroutine(ALoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator ALoadScene(int levelIndex){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime*2);
        SceneManager.LoadScene(levelIndex);
    }

}