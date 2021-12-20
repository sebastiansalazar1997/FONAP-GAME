using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdultManager : MonoBehaviour
{
    public int points = 0;
    public int totalPoints = 4;

    public Text totalCoins;
    public Text coinsCollected;
    public Text shadowTotalCoins;
    public Text shadowCoinsCollected;

    public GameObject panelActivities;
    public GameObject activity1;

    public GameObject transition;
    public GameObject canvasGeneral;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalCoins.text = totalPoints.ToString();
        shadowTotalCoins.text = totalPoints.ToString();
        coinsCollected.text = points.ToString();
        shadowCoinsCollected.text = points.ToString();
        if (points == 4)
        {
            panelActivities.SetActive(true);
            activity1.SetActive(true);
            Time.timeScale = 0f;
            if (Input.GetKeyDown("x") || Input.GetMouseButtonDown(0))
            {
                panelActivities.SetActive(false);
                Time.timeScale = 1f;
                canvasGeneral.SetActive(false);
                ChangeScene();
            }
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("AdultsMenuScene");
    }
}
