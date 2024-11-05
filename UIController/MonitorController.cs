using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorController : MonoBehaviour
{
    [SerializeField]GameObject desktop;
    [SerializeField]GameObject browser;
    [SerializeField]GameObject App1;
    [SerializeField]GameObject App2;
    [SerializeField]GameObject App3;
    [SerializeField]GameObject App4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBrowser(){
        desktop.SetActive(false);
        browser.SetActive(true);
    }

    public void CloseBrowser(){
        desktop.SetActive(true);
        browser.SetActive(false);
    }

}
