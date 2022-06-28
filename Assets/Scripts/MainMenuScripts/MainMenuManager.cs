using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField]
    GameObject playerObj,playerObj2,playerObj3,missileObj,missileObj2,missileObj3;

    
    
    private void Start()
    {
        StartCoroutine(startAction());
    }

    IEnumerator startAction()
    {
        yield return new WaitForSeconds(0.1f);
        playerObj.GetComponent<Transform>().DOMove(new Vector3(0, 50, 0), 2f);
        missileObj.GetComponent<Transform>().DOMove(new Vector3(0, 50, 0), 3f);
        yield return new WaitForSeconds(3.2f);
        playerObj2.GetComponent<Transform>().DOMove(new Vector3(80.9f, -87.9f, -26.8f), 4f);
        missileObj2.GetComponent<Transform>().DOMove(new Vector3(80.9f, -87.9f, -26.8f),5f);
        yield return new WaitForSeconds(4.2f);
        playerObj3.GetComponent<Transform>().DOMove(new Vector3(-98.5f, 1.5f, -10.7f), 4f);
        missileObj3.GetComponent<Transform>().DOMove(new Vector3(-98.5f, 1.5f, -10.7f), 3.60f);
        yield return new WaitForSeconds(1.35f);
        CanvasScripts.instance.OpenCanvas();

    }

    
}
