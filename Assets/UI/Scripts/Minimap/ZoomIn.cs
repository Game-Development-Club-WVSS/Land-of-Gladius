using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomIn : MonoBehaviour
{
    public RectTransform Border1;
    public RectTransform Border2;
    public GameObject ZoomOutButton;

    void OnClick()
    {
        Border1.sizeDelta = new Vector2(Border1.sizeDelta[0], 68);
        Border2.localScale = new Vector3(2.5f, 2.5f, 1);
        ZoomOutButton.SetActive(true);
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
