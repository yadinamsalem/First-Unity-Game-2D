using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // Player
    public Vector3 offset; //
    public Vector2 minBoundary; // Minimum X and Y positions for the camera.
    public Vector2 maxBoundary; // Maximum X and Y positions for the camera.


    private void Start()
    {
        offset.z = -0.35f;
        transform.position = new Vector3(0, 0, transform.position.z);
        SetCameraBoundaries();
    }

    private void Update()
    {

        Vector3 newPosition = target.position + offset;
        //Limit X-Y into scene range.
        newPosition.x = Mathf.Clamp(newPosition.x, minBoundary.x, maxBoundary.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBoundary.y, maxBoundary.y);
        transform.position = newPosition;

    }

    private void SetCameraBoundaries()
    {
        minBoundary.x = -0.246f;
        minBoundary.y = 0;
        maxBoundary.x = 8.026f;
        maxBoundary.y = 0;
    }


}
