using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomOut : MonoBehaviour
{
    public RectTransform Border1;
    public RectTransform Border2;
    public GameObject ZoomInButton;

    void OnClick()
    {
        Border1.sizeDelta = new Vector2(Border1.sizeDelta[0], 136);
        Border2.localScale = new Vector3(5, 5, 1);
        ZoomInButton.SetActive(true);
        this.gameObject.SetActive(false);
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
