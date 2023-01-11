using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenWindow: MonoBehaviour
{
    public GameObject window;
    public GameObject windowsCenter;

    private WindowsControl windowControl;

    void OnClick()
    {
        windowControl.openWindow(window);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
        windowControl = windowsCenter.GetComponent<WindowsControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
