using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject scoreBoard,scoreUýBackground, scoreLabel, scoreTxt, maxScoreLabel, maxScoreTxt,okBtn,restartBtn;
    [SerializeField] TextMeshProUGUI currentScore, maxScore;

    private void Start()
    {
        setScore();
        StartCoroutine(openUIComp());
    }

    private void setScore()
    {
        currentScore.text = PlayerPrefs.GetInt("CurrentScore").ToString();
        maxScore.text = PlayerPrefs.GetInt("MaxScore").ToString();
    }

    
    IEnumerator openUIComp()
    {
        scoreUýBackground.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.InCubic);
        scoreUýBackground.GetComponent<CanvasGroup>().DOFade(1, 1f).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(1f);
        scoreBoard.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.InCubic);
        scoreBoard.GetComponent<CanvasGroup>().DOFade(1, 1f).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(1f);
        scoreLabel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.InCubic);
        scoreLabel.GetComponent<CanvasGroup>().DOFade(1, 1f).SetEase(Ease.InCubic);
        scoreTxt.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.InCubic);
        scoreTxt.GetComponent<CanvasGroup>().DOFade(1, 1f).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(1f);
        maxScoreLabel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.InCubic);
        maxScoreLabel.GetComponent<CanvasGroup>().DOFade(1, 1f).SetEase(Ease.InCubic);
        maxScoreTxt.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.InCubic);
        maxScoreTxt.GetComponent<CanvasGroup>().DOFade(1, 1f).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(1f);
        okBtn.SetActive(true);
        restartBtn.SetActive(true);
    }

    public void OkBtnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartBtnClick()
    {
        SceneManager.LoadScene(1);
    }

}
