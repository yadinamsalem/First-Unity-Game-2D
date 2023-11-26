using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        switch (SceneManager.GetActiveScene().name) // Change boundries according level name specifications.
        {
            case "Level 1":
                //                                   (xMin   , xMax  ),           (yMin   , yMax  ) 
                SetCameraBoundariesValues(new Vector2(-0.246f, 8.026f), new Vector2(0, 0));
                break;
            case "Level 2":
                SetCameraBoundariesValues(new Vector2(-0.246f, 8.026f), new Vector2(0, 12));
                break;
        }
    }

    private void SetCameraBoundariesValues(Vector2 xVect, Vector2 yVect)
    {
        minBoundary.x = xVect.x;
        minBoundary.y = yVect.x;
        maxBoundary.x = xVect.y;
        maxBoundary.y = yVect.y;
    }


}
