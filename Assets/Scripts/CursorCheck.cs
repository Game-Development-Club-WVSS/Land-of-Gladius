using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCheck : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    Vector3 target;
    GameObject curGameObject;
    public Texture2D CursorImage;

    GameObject preGameObject;
    Material preMaterial;
    public Material highlight;
    bool hasPreGameObject = false;
    public GameObject WeaponRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.SetCursor(CursorImage,new Vector2(0,0),CursorMode.Auto);
    }

    bool isPress = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Cursor.lockState == CursorLockMode.None) Cursor.lockState = CursorLockMode.Locked;
            else Cursor.lockState = CursorLockMode.None;
        }


        Ray ray = Camera.main.ScreenPointToRay(this.transform.position);
        if (Physics.Raycast(ray, out hit))
        {
            //绘制出一条从相机射出的红色射线
            //Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);

            target = hit.point;//获取鼠标的坐标位置
            curGameObject = hit.transform.gameObject;//获取鼠标点击的物体信息
        }

        //当按下鼠标左键时
        if (Input.GetMouseButton(0))
        {
            if(isPress == false)
            {
                isPress = true;
                //鼠标在屏幕的位置

            }
        }
        else isPress = false;


        if (hasPreGameObject && preGameObject != curGameObject)
        {
            preGameObject.GetComponent<MeshRenderer>().material = preMaterial;
            hasPreGameObject = false;
        }

        if (curGameObject&&curGameObject.transform.parent.gameObject.tag == "Weapon Selection")
        {
            Debug.Log("鼠标点击的物体信息:" + curGameObject.tag);

            if (!hasPreGameObject || curGameObject != preGameObject)
            {
                preMaterial = curGameObject.GetComponent<MeshRenderer>().material;
                curGameObject.GetComponent<MeshRenderer>().material = highlight;
                preGameObject = curGameObject;
                hasPreGameObject = true;
            }
            if (Input.GetMouseButton(0))
            {
                WeaponRotation.GetComponent<WeaponRotate>().DisappearWeaponSelection();
            }
        }
    }
}
