using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class Register : MonoBehaviour
{
    private string URL = "http://localhost:3000/register";
    
    public InputField inputName;
    public InputField inputAge;
    public InputField inputCommunity;
    public Toggle toggleIsAffiliate;
    public Button submitButton;
    public GameObject messageBox;

    public void Submit()
    {
        submitButton.interactable = false;

        if (inputName.text != "" && inputAge.text != "" && int.Parse(inputAge.text) > 0)
        {
            StartCoroutine(SubmitForm());
        }
        else
        {
            messageBox.SetActive(true);
        }
    }

    public void CloseModal()
    {
        messageBox.SetActive(false);
        submitButton.interactable = true;
    }

    IEnumerator SubmitForm()
    {
        WWWForm form = GenerateForm(inputName.text, int.Parse(inputAge.text), inputCommunity.text, toggleIsAffiliate.isOn);

        UnityWebRequest unityWebRequest = UnityWebRequest.Post(URL, form);
        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
        {
            Debug.Log(unityWebRequest.error);
            submitButton.interactable = true;
            yield break;
        }

        JSONNode data = JSON.Parse(unityWebRequest.downloadHandler.text);
        PlayerPrefs.SetInt("user_id", data["data"][0]);

        if (int.Parse(inputAge.text) >= 0 && int.Parse(inputAge.text) <= 12)
        {
            PlayerPrefs.SetString("game_type", "kids");
            SceneManager.LoadScene("KidsMenuScene");
        }
        else if (int.Parse(inputAge.text) >= 13 && int.Parse(inputAge.text) <= 24)
        {
            PlayerPrefs.SetString("game_type", "teens");
            SceneManager.LoadScene("TeensMenuScene");
        }
        else if (int.Parse(inputAge.text) >= 25)
        {
            PlayerPrefs.SetString("game_type", "adults");
            SceneManager.LoadScene("AdultsMenuScene");
        }
    }

    WWWForm GenerateForm(string name, int age, string community, bool is_affiliate)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("age", age);
        form.AddField("community", community);
        form.AddField("is_affiliate", is_affiliate? 1: 0);

        return form;
    }
}
