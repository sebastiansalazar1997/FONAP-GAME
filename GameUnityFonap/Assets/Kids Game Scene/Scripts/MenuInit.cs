using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInit : MonoBehaviour
{
    public float speedParallax = 0.02f;
    public RawImage clouds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float finalSpeed = speedParallax * Time.deltaTime;
        clouds.uvRect = new Rect(clouds.uvRect.x + finalSpeed, 0f, 1f, 1f);
    }
}
