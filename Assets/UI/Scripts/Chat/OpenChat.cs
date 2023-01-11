using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChat : MonoBehaviour
{
    public GameObject chatWindow;
    public GameObject leftLayer;

    void OnClick()
    {
        chatWindow.SetActive(true);
        leftLayer.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
