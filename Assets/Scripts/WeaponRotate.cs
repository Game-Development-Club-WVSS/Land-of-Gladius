using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UIElements;

public class WeaponRotate : MonoBehaviour{
    public float radius = 1f;
    public float height = 0.5f;
    public Transform Player;
    Transform[] children;

    public GameObject[] Swords, Spears, Claymores, Wands, Bows, Arrows, Shields;
    GameObject[] Weapons = { };
    string lastWeaponType;

    public void DisappearWeaponSelection()
    {
        lastWeaponType = "";
        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].SetActive(false);
        }
        Weapons = new GameObject[0];
    }

    public void SetWeaponPosition(String weaponType)
    {
        Debug.Log(weaponType);
        if (lastWeaponType == weaponType) return;
        DisappearWeaponSelection();
        lastWeaponType = weaponType;

        if (weaponType == "Swords") Weapons = (GameObject[])Swords.Clone();
        if (weaponType == "Spears") Weapons = (GameObject[])Spears.Clone();
        if (weaponType == "Claymores") Weapons = (GameObject[])Claymores.Clone();
        if (weaponType == "Wands") Weapons = (GameObject[])Wands.Clone();
        if (weaponType == "Bows") Weapons = (GameObject[])Bows.Clone();
        if (weaponType == "Arrows") Weapons = (GameObject[])Arrows.Clone();
        if (weaponType == "Shields") Weapons = (GameObject[])Shields.Clone();

        float angle = 0;
        for (int i = 0; i < Weapons.Length; i++)
        {
            GameObject weapon = Weapons[i];
            weapon.SetActive(true);

            //Vector3 childRotation = weapon.transform.localEulerAngles;
            //childRotation.y = UnityEngine.Random.Range(0f, 360f);
            //weapon.transform.localEulerAngles = childRotation;

            Vector3 childPosition = weapon.transform.localPosition;
            childPosition.x = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            childPosition.z = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            angle += 360f / Weapons.Length;
            weapon.transform.localPosition = childPosition;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //SetWeaponPosition(Wands);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisappearWeaponSelection();
        }

        Vector3 rotation = transform.eulerAngles;
        rotation.y += 10 * Time.deltaTime;
        transform.eulerAngles = rotation;

        //Vector3 position = Player.position;
        //position.y += height;
        //transform.position = position;

        for (int i = 0; i < Weapons.Length; i++)
        {
            GameObject weapon = Weapons[i];
            weapon.transform.localEulerAngles = weapon.transform.localEulerAngles + new Vector3(0, -30, 0) * Time.deltaTime;
        }
    }
}
