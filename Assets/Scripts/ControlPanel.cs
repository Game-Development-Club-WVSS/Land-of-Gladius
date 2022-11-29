using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject weaponSelect;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WeaponSelect()
    {
        if (weaponSelect.active == true) weaponSelect.SetActive(false);
        else weaponSelect.SetActive(true);
    }
}
