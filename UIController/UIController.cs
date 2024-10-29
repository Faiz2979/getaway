using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class UIController : MonoBehaviour
{
    public bool isPaused = false;
    [SerializeField]PlayerController player;
    [SerializeField]Animator anim;
    [SerializeField]AudioSource bgsound;
    
    [Header("UI")]
    public GameObject mainUI;
    public GameObject menu;
    public GameObject profileMenu;
    public GameObject settingMenu;
    private GameObject lastOpenedMenu;

    // Update is called once per frame
    void Update()
    {
        HandlePause();
    }


    public void StopMovement(){
        player.rb.velocity = Vector2.zero;
        player.xInput = 0;
        player.yInput = 0;
        bgsound.mute = !bgsound.mute;
        player.isMoving = !player.isMoving;
        player.enabled = !player.enabled;
        anim.enabled=!anim.enabled;
    }

    public void HandlePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                StopMovement();
                mainUI.SetActive(false);
                if (lastOpenedMenu != null)
                {
                    lastOpenedMenu.SetActive(true);
                }
                else
                {
                    profileMenu.SetActive(true);
                }
            }
            else
            {
                StopMovement();
                mainUI.SetActive(true);
                if (lastOpenedMenu != null)
                {
                    lastOpenedMenu.SetActive(false);
                }
                else
                {
                    profileMenu.SetActive(false);
                }
            }
        }
    }
    public void OpenSettingMenu()
    {
        isPaused = true;
        settingMenu.SetActive(true);
        profileMenu.SetActive(false);
        mainUI.SetActive(false);
        lastOpenedMenu = settingMenu;
    }

    public void OpenProfileMenu()
    {
        isPaused = true;
        profileMenu.SetActive(true);
        settingMenu.SetActive(false);
        mainUI.SetActive(false);
        lastOpenedMenu = profileMenu;
    }

    public void QuitGame(){
        PlayerDetail playerDetail = FindObjectOfType<PlayerDetail>();
        playerDetail.SavePlayer();
        Application.Quit();
    }

    void BackgroundVolume(){

    }
}
