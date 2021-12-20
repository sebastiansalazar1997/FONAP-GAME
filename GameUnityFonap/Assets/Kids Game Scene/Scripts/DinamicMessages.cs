using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinamicMessages : MonoBehaviour
{
    public string[] messages;
    public Text output;

    private int index = 0;

    public void showMessage()
    {
        if (index >= messages.Length)
        {
            index = 0;
        }
        output.text = messages[index];
        index++;
    }
}
