using UnityEngine;
using System.Collections;

public class RotateSphere : MonoBehaviour
{
    float rotateSpeed = 2f;
    float rotateAboutY;
    public Vector2 startPos;
    public Vector2 direction;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {  // If left mouse button down:

            Touch userTouch = Input.GetTouch(0);

            switch (userTouch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = userTouch.position;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:

                    rotateAboutY = Input.GetAxis("Mouse X") * rotateSpeed;
                    //direction = userTouch.position - startPos;

                    //if (direction.x > 0)
                    //{
                    //    rotateAboutY += Input.GetAxis("Mouse X") * rotateSpeed;
                    //}// Mouse movement right/left.

                    //else
                    //{
                    //    rotateAboutY -= Input.GetAxis("Mouse X") * rotateSpeed;
                    //}
                    gameObject.transform.Rotate(0.0f, rotateAboutY, 0.0f);   // Rotate the (camera) object around X and Y.

                    // Lock z rotation to 0 so camera doesn't 'roll' sideways.
                    // We only want the camera's yaw (y) and pitch (x) to change.
                    var newRotation = gameObject.transform.rotation.eulerAngles;
                    newRotation.z = 0;
                    gameObject.transform.rotation = Quaternion.Euler(newRotation);
                    break;
            }
            
            float rotateAboutX = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;    // Mouse movement up/down.


        }
    }
}