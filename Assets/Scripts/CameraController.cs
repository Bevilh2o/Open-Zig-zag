using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ball;
    Vector3 offset; //Distance between ball and camera
    public float lerpRate;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        offset = ball.transform.position - transform.position; //Calculates the distance between ball and camera
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
            Follow();
        
    }

    void Follow()
    {
        Vector3 pos = transform.position; //Calculates the current cam position 
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
