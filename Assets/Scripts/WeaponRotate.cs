using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponRotate : MonoBehaviour{
    public Transform Player;
    Transform[] children;

    // Start is called before the first frame update
    void Start(){
        children = GetComponentsInChildren<Transform>();
        float angle = 0;
        foreach (Transform child in children){
            if (child == transform) continue;

            Vector3 childRotation = child.transform.localEulerAngles;
            childRotation.y = UnityEngine.Random.Range(0f, 360f);
            child.transform.localEulerAngles = childRotation;

            Vector3 childPosition = child.transform.localPosition;
            childPosition.x = 2f * Mathf.Sin(angle * Mathf.Deg2Rad);
            childPosition.z = 2f * Mathf.Cos(angle * Mathf.Deg2Rad);
            angle += 360f / (children.Length - 1);
            child.transform.localPosition = childPosition;
        }
    }

    // Update is called once per frame
    void LateUpdate(){
        Vector3 rotation = transform.eulerAngles;
        rotation.y += 10 * Time.deltaTime;
        transform.eulerAngles = rotation;

        Vector3 position = Player.position;
        position.y -= 0.25f;
        transform.position = position;

        foreach (Transform child in children){
            if (child == transform) continue;

            Vector3 childRotation = child.transform.localEulerAngles;
            childRotation.y -= 30 * Time.deltaTime;
            child.transform.localEulerAngles = childRotation;
        }
    }
}
