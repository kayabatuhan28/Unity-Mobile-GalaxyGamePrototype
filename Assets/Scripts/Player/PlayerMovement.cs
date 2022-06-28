using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    Rigidbody rb;

    [SerializeField]
    public float moveSpeedTimer,moveSpeedIncreaseRate,moveSpeed,rotateSpeed,currentUpAmount;

    [SerializeField]
    Joystick joystick;


    [SerializeField] GameObject explosionVfx,fuelVfx;

    public bool playerDie;


    [HideInInspector]
    public int score,maxScore;

    [SerializeField]
    TextMeshProUGUI scoreTxt;

    [SerializeField]
    public float scoreTimer, nextscore;

    [SerializeField]
    GameObject endImg;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        instance = this;
    }

    private void FixedUpdate()
    {
        ScoreUp();
        PlayerMove();
        speedUp();
        
    }

    private void Start()
    {
        playerDie = false;
    }

    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag == "Enemy")
        {
            playerDie = true;
            Instantiate(explosionVfx, transform.position, transform.rotation);
            gameObject.GetComponent<Transform>().localScale = Vector3.zero;
            openEndScene();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fuel")
        {
            Fuelup();
            Instantiate(fuelVfx, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
    }

    public void speedUp()
    {
        if (Time.time > moveSpeedTimer)
        {
            moveSpeedTimer += moveSpeedIncreaseRate;
            moveSpeed += 1f * Time.deltaTime;
            
            
        }
    }

    public void Fuelup()
    {
        
         if(CircularProgressBar.instance.m_FillAmount + 0.25f >= 1)
         {
             CircularProgressBar.instance.m_FillAmount = 1f;
         }
         else
         {
             CircularProgressBar.instance.m_FillAmount += 0.25f;
         }

        

    }

    public void ScoreUp()
    {
        
        if(Time.time > nextscore && !playerDie)
        {
            score++;
            scoreTxt.text = score.ToString();
            nextscore = Time.time + scoreTimer;
        }

       
        
    }

    public void PlayerMove()
    {
        float verticalMove = joystick.Vertical;
        float horizontalMove = joystick.Horizontal;

        if (horizontalMove <= -0.25f && verticalMove <= 0.25f)
        {
            transform.Rotate(new Vector3(0, 0, +1) * Time.deltaTime * rotateSpeed);
        }

        if (horizontalMove >= 0.25f && verticalMove <= 0.25f)
        {
            transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * rotateSpeed);
        }

        if (verticalMove >= 0.25f)
        {
            if (CircularProgressBar.instance.m_FillAmount > 0)
            {
                rb.velocity = transform.up * Time.deltaTime * moveSpeed;
                CircularProgressBar.instance.m_FillAmount -= 0.05f * Time.deltaTime;
            }
        }

    }

    public void ScoreController(int currentScore)
    {
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        if (PlayerPrefs.HasKey("MaxScore"))
        {
            if(currentScore > PlayerPrefs.GetInt("MaxScore"))
            {
                PlayerPrefs.SetInt("MaxScore", currentScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("MaxScore", score);
        }

    }

    IEnumerator EndGameSet()
    {
        ScoreController(score);
        yield return new WaitForSeconds(1f);
        endImg.SetActive(true);
        endImg.GetComponent<CanvasGroup>().DOFade(1, 1f);
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(2);
        
    }

    private void openEndScene()
    {
        StartCoroutine(EndGameSet());
    }


}
