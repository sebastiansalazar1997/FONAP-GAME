using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CoinsManager : MonoBehaviour
{
    public Text totalCoins;
    public Text coinsCollected;
    private int totalCoinsCount;
    private int counter;

    public Text shadowTotalCoins;
    public Text shadowCoinsCollected;

    public GameObject door;

    public GameObject panelActivities;
    public GameObject activity1;
    public GameObject activity2;
    public GameObject activity3;
    public bool gameIsPaused = false;

    bool verifyActivity1 = true;
    bool verifyActivity2 = true;
    bool verifyActivity3 = true;

    public AudioSource clipOpenActivity;
    public AudioSource clipCloseActivity;

    public bool coinsIsComplete = false;
    public GameObject lettersManager;
    public bool lettersIsComplete;

    public GameObject transition;
    public GameObject canvasGeneral;

    private void Start()
    {
        totalCoinsCount = transform.childCount;
        panelActivities.SetActive(false);
    }

    private void Update()
    {   
        lettersIsComplete = lettersManager.GetComponent<LettersManager>().lettersIsComplete;
        AllCoinsCollected();
        totalCoins.text = totalCoinsCount.ToString();
        shadowTotalCoins.text = totalCoinsCount.ToString();
        counter = totalCoinsCount - transform.childCount;
        coinsCollected.text = counter.ToString();
        shadowCoinsCollected.text = counter.ToString();

        if (!gameIsPaused)
        {
            switch (counter)
            {
                case 5:
                    if (verifyActivity1)
                    {
                        panelActivities.SetActive(true);
                        activity1.SetActive(true);
                        gameIsPaused = true;
                        verifyActivity1 = false;
                        clipOpenActivity.Play();
                    }
                    break;
                case 10:
                    if (verifyActivity2)
                    {
                        panelActivities.SetActive(true);
                        activity1.SetActive(false);
                        activity2.SetActive(true);
                        gameIsPaused = true;
                        verifyActivity2 = false;
                        clipOpenActivity.Play();
                    }
                    break;
                case 15:
                    if (verifyActivity3)
                    {
                        panelActivities.SetActive(true);
                        activity2.SetActive(false);
                        activity3.SetActive(true);
                        gameIsPaused = true;
                        verifyActivity3 = false;
                        clipOpenActivity.Play();
                    }
                    break;
            }
        }
        else if (gameIsPaused)
        {
            Time.timeScale = 0f;
            if (Input.GetKeyDown("x") || Input.GetMouseButtonDown(0))
            {
                panelActivities.SetActive(false);
                Time.timeScale = 1f;
                gameIsPaused = false;
                clipCloseActivity.Play();

                if (coinsIsComplete && lettersIsComplete)
                {
                    canvasGeneral.SetActive(false);
                    transition.SetActive(true);
                    Invoke("ChangeScene", 1.1f);
                }

            }    
        }
    }

    public void AllCoinsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Todas las monedas recogidas. VICTORIA!!");
            lettersIsComplete = true;
            coinsIsComplete = true;
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("QuestScene");
    }
}
