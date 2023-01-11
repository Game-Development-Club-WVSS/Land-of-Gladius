using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float barWidth = 1000;
    public float lowBloodStautsPercent = 30;
    public Color regularStatusColor;
    public Color lowBloodStatusColor;
    public GameObject healthBar;
    public GameObject healthText;
    public GameObject Player;

    private CombatSystem CombatSystem;
    private RectTransform HealthBarRect;
    private RawImage HealthBarRawImage;
    private TMP_Text HealthBarText;

    // Start is called before the first frame update
    void Start()
    {
        CombatSystem = Player.GetComponent<CombatSystem>();
        HealthBarRect = healthBar.GetComponent<RectTransform>();
        HealthBarRawImage = healthBar.GetComponent<RawImage>();
        HealthBarText = healthText.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int HP = CombatSystem.HP;
        int health = CombatSystem.health;
        float targetWidth = barWidth * health / HP;
        float currentWidth = HealthBarRect.sizeDelta[0];
        float currentHeight = HealthBarRect.sizeDelta[1];

        float widthChangingSpeed = 0.2f;
        if (targetWidth < currentWidth) widthChangingSpeed = 0.2f;
        else widthChangingSpeed = 0.5f;
        HealthBarRect.sizeDelta = new Vector2(currentWidth + (targetWidth - currentWidth) * widthChangingSpeed, currentHeight);

        float colorChangingSpeed = 0.2f;
        Color targetColor;
        if (health * 100 <= lowBloodStautsPercent * HP)
        {
            targetColor = lowBloodStatusColor;
            colorChangingSpeed = 0.2f;
        }
        else
        {
            targetColor = regularStatusColor;
            colorChangingSpeed = 0.5f;
        }
        HealthBarRawImage.color += (targetColor - HealthBarRawImage.color) * colorChangingSpeed;
        HealthBarText.text = Convert.ToString(health) + " / " + Convert.ToString(HP);
    }
}
