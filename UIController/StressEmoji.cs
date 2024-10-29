using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressEmoji : MonoBehaviour
{
    [SerializeField]PlayerStats playerStats;
    [SerializeField]Sprite Stress1;
    [SerializeField]Sprite Stress2;
    [SerializeField]Sprite Stress3;
    [SerializeField]Sprite Stress4;
    [SerializeField]Sprite Stress5;
    [SerializeField]int Stress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EmojiHandler();
    }

    public void EmojiHandler(){
        Stress = playerStats.Stress;
        if(Stress <=20){
            GetComponent<Image>().sprite = Stress1;
        }
        else if(Stress <=40){
            GetComponent<Image>().sprite = Stress2;
        }
        else if(Stress <= 60){
            GetComponent<Image>().sprite = Stress3;
        }
        else if(Stress <= 80){
            GetComponent<Image>().sprite = Stress4;
        }
        else if(Stress <100){
            GetComponent<Image>().sprite = Stress5;
        }
    }
}
