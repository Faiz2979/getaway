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
    [SerializeField]GameObject reputation;
    [SerializeField]GameObject BackButton;
    [SerializeField]PlayerStats reputationData;
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
        if(player !=null||anim !=null||mainUI !=null){
        player.rb.velocity = Vector2.zero;
        player.xInput = 0;
        player.yInput = 0;
        bgsound.mute = false;
        player.isMoving = false;
        player.enabled = false;
        anim.enabled=false;
        }else{
            //without Player and Animation
            BackButton.SetActive(false);
            bgsound.mute = false;
        }
    }
    public void ResumeGame(){
        if(player !=null||anim !=null||mainUI !=null){
        isPaused = false;
        mainUI.SetActive(true);
        menu.SetActive(false);
        if (lastOpenedMenu != null)
        {
            lastOpenedMenu.SetActive(false);
        }
        else
        {
            profileMenu.SetActive(false);
        }
        player.enabled =true;
        anim.enabled=true;
        bgsound.mute =false;
        }
        else{
            //without Player and Animation
        isPaused = false;
        BackButton.SetActive(true);
        menu.SetActive(false);
        if (lastOpenedMenu != null)
        {
            lastOpenedMenu.SetActive(false);
        }
        else
        {
            profileMenu.SetActive(false);
        }
            bgsound.mute = false;
        }
    }
    public void HandlePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                StopMovement();
                menu.SetActive(true);
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
                ResumeGame();
                menu.SetActive(false);
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
        StopMovement();
        mainUI.SetActive(false);
        menu.SetActive(true);
        profileMenu.SetActive(false);
        lastOpenedMenu = settingMenu;
        settingMenu.SetActive(true);
    }

    public void OpenProfileMenu()
    {
        isPaused = true;
        StopMovement();
        menu.SetActive(true);
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
