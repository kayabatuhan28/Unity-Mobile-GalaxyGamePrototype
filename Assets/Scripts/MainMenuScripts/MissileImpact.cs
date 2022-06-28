using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileImpact : MonoBehaviour
{

    [SerializeField]
    GameObject missileVfx;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(missileVfx, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
