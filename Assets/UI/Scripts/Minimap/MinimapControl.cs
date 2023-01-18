using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;

public class MinimapControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float MinimumDisplaySize = 10;
    public float MaximumDisplaySize = 500;
    public float DisplaySizeOffset = 1.5f;
    public float DisplaySize = 5;
    public float RotationSpeed = 0.1f;
    public Transform FollowingPlayer;
    public Transform ProjectedCamera;

    public void IncreaseDisplaySize()
    {
        DisplaySize /= DisplaySizeOffset;
        if (DisplaySize < MinimumDisplaySize) DisplaySize = MinimumDisplaySize;
    }
    
    public void DecreaseDisplaySize()
    {
        DisplaySize *= DisplaySizeOffset;
        if (DisplaySize > MaximumDisplaySize) DisplaySize = MaximumDisplaySize;
    }

    void Start()
    {
        ProjectedCamera.eulerAngles = new Vector3(90, FollowingPlayer.eulerAngles.y, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ProjectedCamera.GetComponent<Camera>().orthographicSize = DisplaySize;

        Vector3 Position = FollowingPlayer.position;
        Position.y = -500;
        ProjectedCamera.position = Position;
        
        float error = FollowingPlayer.eulerAngles.y - ProjectedCamera.eulerAngles.y;
        error %= 360;
        if (error > 180) error -= 360;
        if (error < -180) error += 360;
        ProjectedCamera.eulerAngles = new Vector3(90, ProjectedCamera.eulerAngles.y + error * RotationSpeed, 0);
    }
}
