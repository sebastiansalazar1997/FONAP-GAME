using UnityEngine;
using UnityEngine.UI;

public class DecisionManager : MonoBehaviour
{
    public GameObject decisionMessage;

    public Button m_buttonHelp, m_buttonNotHelp;
    public GameObject player;
    private AdultManager adultManager;

    public bool isKidsHelped = false;
    private DinamicMessages dinamicMessages;
    public string keyMessage;

    public GameObject kid1, kid2;
    public Sprite spr_kid1, spr_kid2;
    // Start is called before the first frame update
    void Start()
    {
        adultManager = player.GetComponent<AdultManager>();
        dinamicMessages = decisionMessage.GetComponent<DinamicMessages>();
        m_buttonHelp.onClick.AddListener(HelpKids);
        m_buttonNotHelp.onClick.AddListener(IgnoreKids);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dinamicMessages.showMessage();

            decisionMessage.SetActive(true);
            if (!isKidsHelped)
            {
                m_buttonHelp.gameObject.SetActive(true);
                m_buttonNotHelp.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            decisionMessage.SetActive(false);
            m_buttonHelp.gameObject.SetActive(false);
            m_buttonNotHelp.gameObject.SetActive(false);
        }
    }

    void HelpKids()
    {
        m_buttonHelp.gameObject.SetActive(false);
        m_buttonNotHelp.gameObject.SetActive(false);
        dinamicMessages.output.text = keyMessage;
        dinamicMessages.messages[0] = keyMessage;
        isKidsHelped = true;
        adultManager.points = adultManager.points + 2;
        kid1.GetComponent<SpriteRenderer>().sprite = spr_kid1;
        kid2.GetComponent<SpriteRenderer>().sprite = spr_kid2;
    }

    void IgnoreKids()
    {
        m_buttonHelp.gameObject.SetActive(false);
        m_buttonNotHelp.gameObject.SetActive(false);
        dinamicMessages.output.text = "Decidiste no hacer nada.";
    }
}
