using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    //If the player collides with the death plane below the level, the player loses all their health.
    private void OnTriggerEnter(Collider other)
    {
        ActionManager ply = other.GetComponent<ActionManager>();
        ply.DamagePlayer(110);
 
    }
}
