using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
//using UnityEditor.EditorTools;
using UnityEngine;

public class PartyMonsterMovement : MonoBehaviour
{
    public float detectionDistance = 10;
    public float attackDistance = 2;
    public float speed = 7;
    private Transform player;
    private CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cc = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //bool isRun = false;
        Vector3 targetPosition = player.position;
        float distance = Vector3.Distance(targetPosition, transform.position);
        if (distance <= detectionDistance)
        {
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
            if(distance<= attackDistance)
            {

            }
            else
            {
                cc.SimpleMove(transform.forward * speed * Time.deltaTime * 100);
            }
        }
    }
}
