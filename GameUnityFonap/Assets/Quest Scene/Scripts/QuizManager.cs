using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;

public class QuizManager : MonoBehaviour
{
    private string URL = "http://localhost:3000/score";
    private bool inHallFame = false;

    public Text[] nameTexts;
    public Text[] scoreTexts;

    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;
    public GameObject HighScoresPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    public GameObject goTransition;

    int totalQuestions = 0;
    public int score;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    private void Update()
    {
        if (inHallFame && (Input.GetKeyDown("x") || Input.GetMouseButtonDown(0)) )
        {
            inHallFame = false;
            HighScoresPanel.SetActive(false);
            GoPanel.SetActive(true);
            ScoreTxt.text = score + "/" + totalQuestions;
        }
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void finish()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        goTransition.SetActive(true);
        Invoke("ChangeScene", 0.8f);
    }

    public void ShowHighScores()
    {
        inHallFame = true;
        GoPanel.SetActive(false);
        HighScoresPanel.SetActive(true);

        StartCoroutine(GetHighScores());
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;

        StartCoroutine(SaveDataInDatabase());
    }

    public void correct()
    {
        //when you are right
        score += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(waitForNext());
    }

    public void wrong()
    {
        //when you answer wrong
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(waitForNext());
    }

    IEnumerator waitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            
            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }

    void ChangeScene()
    {
        string gameType = PlayerPrefs.GetString("game_type");

        if (gameType == "kids")
        {
            SceneManager.LoadScene("KidsMenuScene");
        }
        else if (gameType == "teens")
        {
            SceneManager.LoadScene("TeensMenuScene");
        }
        else if (gameType == "adults")
        {
            SceneManager.LoadScene("AdultsMenuScene");
        }
        else
        {
            SceneManager.LoadScene("RegisterScene");
        }
    }

    IEnumerator SaveDataInDatabase()
    {
        int userID = PlayerPrefs.GetInt("user_id");

        WWWForm form = new WWWForm();
        form.AddField("id", userID);
        form.AddField("score", score);

        UnityWebRequest unityWebRequest = UnityWebRequest.Post(URL, form);

        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
        {
            Debug.Log(unityWebRequest.error);
            yield break;
        }
    }

    IEnumerator GetHighScores()
    {

        UnityWebRequest unityWebRequest = UnityWebRequest.Get(URL);

        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
        {
            Debug.Log(unityWebRequest.error);
            yield break;
        }

        JSONNode highScores = JSON.Parse(unityWebRequest.downloadHandler.text);

        for (int i = 0; i < highScores.Count; i++)
        {
            nameTexts[i].text = i+1 + ". " + highScores[i]["name"];
            scoreTexts[i].text = highScores[i]["score"];
        }
    }
}
