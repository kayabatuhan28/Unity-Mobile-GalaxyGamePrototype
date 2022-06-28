using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class CanvasScripts : MonoBehaviour
{
    public static CanvasScripts instance;
    [SerializeField]
    GameObject gameTitlePanel, gameTitle, ButtonPanel, StartBtn, settingsButton,LevelEndImg;

    [SerializeField]
    string gameScene;

    private void Awake()
    {
        instance = this;
    }

    public void OpenCanvas()
    {
        StartCoroutine(CanvasIenumerator());
    }

    IEnumerator CanvasIenumerator()
    {
        yield return new WaitForSeconds(0.01f);
        gameTitlePanel.SetActive(true);
        ButtonPanel.SetActive(true);
        gameTitle.GetComponent<CanvasGroup>().DOFade(1, 1f).SetEase(Ease.InBack);
        gameTitle.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(1f);
        StartBtn.GetComponent<CanvasGroup>().DOFade(1, 1f).SetEase(Ease.InBack);
        StartBtn.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(1f);
        settingsButton.GetComponent<CanvasGroup>().DOFade(1, 1f).SetEase(Ease.InBack);
        settingsButton.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.InBack);

    }

    public void StartBtnClick()
    {
        StartCoroutine(endImgOpen());
    }

    IEnumerator endImgOpen()
    {
        LevelEndImg.GetComponent<CanvasGroup>().DOFade(1, 1.2f).SetEase(Ease.InCirc);
        LevelEndImg.GetComponent<RectTransform>().DOScale(1, 1.2f).SetEase(Ease.InCirc);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(gameScene);
    }

    public void SettingsButtonClick()
    {

    }



}
