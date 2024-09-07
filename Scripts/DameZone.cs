using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            //the controller will take care of ignoring the damage during the invincibility time.
            controller.ChangeHealth(-1);
        }

    }

}
