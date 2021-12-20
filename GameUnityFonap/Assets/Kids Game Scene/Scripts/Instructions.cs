using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject canvasSkin;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x") || Input.GetMouseButtonDown(0))
        {
            canvasSkin.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
