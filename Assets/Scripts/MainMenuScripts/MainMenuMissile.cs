using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenuMissile : MonoBehaviour
{
    [SerializeField]
    GameObject playerVfx;

    private void OnCollisionEnter(Collision other)
    {
       
        Instantiate(playerVfx, other.transform.position, other.transform.rotation);
        gameObject.SetActive(false);
        other.gameObject.SetActive(false);

        
    }
}
