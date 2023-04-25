using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByAxis : MonoBehaviour
{
    public float rotatePower;

    // Update is called once per frame
    void Update()
    {
        /*Old code
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotatePower, 0);
        */

        //Player presses left and right arrow keys to rotate the camera's focus around the player.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 1 * rotatePower, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -1 * rotatePower, 0);
        }
    }
}
