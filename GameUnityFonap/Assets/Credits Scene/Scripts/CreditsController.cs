using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    public string _loadSceneMenu;
    public GameObject transition;

    public void ButtonBack()
    {
        transition.SetActive(true);
        Invoke("BackSceneMenu", 1f);
    }

    void BackSceneMenu()
    {
        SceneManager.LoadScene(_loadSceneMenu);
    }
}
