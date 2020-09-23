using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager sgtgamemanager;
    public void Awake()
    {
        if (sgtgamemanager != null)
        {
            Debug.LogWarning("more than one instance found");
            return;
        }
        sgtgamemanager = this;
    }

    #endregion
   
    public int playerScore;
    public Text scoreText;

    //timer
    public float waktu = 10f;
    public Slider slidertimer;
    public bool kalah;

    //score
    public GameObject papanscore;
    public Text scoreskrg, hscore;

    //combo
    int combocount = 0;
    public GameObject tekscombo;
    Coroutine coroutinecombo;

    // singleton
    void Start()
    {
        slidertimer.maxValue = waktu;
        slidertimer.value = waktu;
        
       
    }

    //Update score dan ui
    public void GetScore(int point)
    {
        slidertimer.value = waktu;
        playerScore += point;
        updatescore();
        scoreText.text = playerScore.ToString();
    }
    private void FixedUpdate()
    {
        if (!kalah)
        {
            slidertimer.value -= Time.fixedDeltaTime;
            if (slidertimer.value == 0)
            {
                fungsikalah();
            }
        }
    }

    void fungsikalah() {
        kalah = true;
        papanscore.SetActive(true);
    }
    public void restartscene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void updatescore() {
        scoreskrg.text = "Score : " + playerScore;
        if (playerScore > nilaitetap.highscore)
        {
            nilaitetap.highscore = playerScore;
            hscore.text = "Highscore : " + nilaitetap.highscore;
        }
        else {

            hscore.text = "Highscore : " + nilaitetap.highscore;
        }
    }

    public void updatecombo()
    {
        combocount++;
        if (combocount > 2)
        {
            tekscombo.SetActive(true);
        tekscombo.GetComponent<Text>().text = "Combo " + combocount;
        
            if (coroutinecombo != null)
            {
                StopCoroutine(coroutinecombo);
            }
            coroutinecombo = StartCoroutine(combodelay());
        }
    }

    IEnumerator combodelay() {
        yield return new WaitForSeconds(5f);
        tekscombo.SetActive(false);
    }

    public void resetcombo() {
        if (coroutinecombo != null)
        {
            StopCoroutine(coroutinecombo);
        }
        tekscombo.SetActive(false);
        combocount = 0;
    }
}

