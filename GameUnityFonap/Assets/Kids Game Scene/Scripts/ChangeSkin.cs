using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public string player_1;
    public string player_2;

    public GameObject skinsPanel;
    public GameObject player;
    public GameObject initialText;

    public void SetSkinMan()
    {
        PlayerPrefs.SetString("PlayerSelected", player_1);
        ResetPlayerSkin();
    }

    public void SetSkinGirl()
    {
        PlayerPrefs.SetString("PlayerSelected", player_2);
        ResetPlayerSkin();
    }

    void ResetPlayerSkin()
    {
        skinsPanel.SetActive(false);
        player.GetComponent<PlayerSelect>().ChangePlayerSkin();
        initialText.SetActive(true);
    }
}
