using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour
{

    [SerializeField]
    Transform playerLocation;

    private void FixedUpdate()
    {
        if (!PlayerMovement.instance.playerDie)
        {
            transform.position = new Vector3(playerLocation.transform.position.x+3f, playerLocation.transform.position.y, -15f);
        }
        
    }

}
