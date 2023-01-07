using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class MinimapControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float CameraHeight = 20;
    public float RotationSpeed = 0.1f;
    public Transform FollowingPlayer;
    public Transform ProjectedCamera;

    public void SetCameraHeight(float value)
    {
        CameraHeight = value;
    }

    void Start()
    {
        ProjectedCamera.eulerAngles = new Vector3(90, FollowingPlayer.eulerAngles.y, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 Position = FollowingPlayer.position;
        Position.y += CameraHeight;
        ProjectedCamera.position = Position;

        float error = FollowingPlayer.eulerAngles.y - ProjectedCamera.eulerAngles.y;
        ProjectedCamera.eulerAngles = new Vector3(90, ProjectedCamera.eulerAngles.y + error * RotationSpeed, 0);
    }
}
