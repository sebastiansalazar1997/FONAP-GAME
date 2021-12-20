using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject cameraFollow;
    public Vector2 minCamPosition, maxCamPosition;
    public float smoothTime;

    private Vector2 velocity;
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float positionX = Mathf.SmoothDamp(transform.position.x, cameraFollow.transform.position.x, ref velocity.x, smoothTime);
        float positionY = Mathf.SmoothDamp(transform.position.y, cameraFollow.transform.position.y, ref velocity.y, smoothTime);

        transform.position = new Vector3(
            Mathf.Clamp(positionX, minCamPosition.x, maxCamPosition.x),
            Mathf.Clamp(positionY, minCamPosition.y, maxCamPosition.y),
            transform.position.z
        );
    }
}
