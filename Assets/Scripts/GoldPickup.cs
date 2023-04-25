using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public GameObject pickupEffect;

    //When the player collides with one of the gold pickups, heal the player and create a new instance of the pickup effect. Then destory the goldpickup gameobject.
    private void OnTriggerEnter(Collider other)
    {
        ActionManager ply = other.GetComponent<ActionManager>();
        ply.HealPlayer(10);

        //make the position of the pickup effect slight higher on the y axis to make it diplay correctly ingame.
        Vector3 position = transform.position;
        position.y += 0.5f;
        Instantiate(pickupEffect, position, transform.rotation);
        Destroy(this.gameObject);
    }
}
