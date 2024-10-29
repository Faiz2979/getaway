using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSwitcher : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=  GetComponent<Animator>();
    }

    // Update is called once per frame
    public void OpenPopUP()
    {
        anim.SetBool("isOpen", true);
    }
    public void ClosePopUP()
    {
        anim.SetBool("isOpen", false);
    }
}
