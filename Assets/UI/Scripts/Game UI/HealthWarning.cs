using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthWarning : MonoBehaviour
{
    public float lowBloodStautsPercent = 30;
    public Color regularStatusColor;
    public Color lowBloodStatusColor;
    public GameObject Player;

    private CombatSystem CombatSystem;
    private Image HeathWarningImage;

    // Start is called before the first frame update
    void Start()
    {
        CombatSystem = Player.GetComponent<CombatSystem>();
        HeathWarningImage = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int HP = CombatSystem.HP;
        int health = CombatSystem.health;
        Color targetColor;
        if(health*100<= lowBloodStautsPercent * HP)
        {
            targetColor = lowBloodStatusColor;
        }
        else
        {
            targetColor = regularStatusColor;
        }

        HeathWarningImage.color += (targetColor - HeathWarningImage.color) * 0.1f;
    }
}
