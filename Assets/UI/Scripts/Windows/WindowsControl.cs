using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsControl : MonoBehaviour
{
    GameObject currentWindow;

    public void closeWindow()
    {
        if(currentWindow) currentWindow.SetActive(false);
    }

    public void openWindow(GameObject window)
    {
        closeWindow();
        currentWindow = window;
        window.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
