using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject particle;
    [SerializeField] //This is used to display the parameters into Unity.
    private float speed = 0;
    Rigidbody rb;
    bool hasBallStarted = false;
    bool GameOver = false;


    //Awake is called when the application starts
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBallStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                hasBallStarted = true;
                PlatformSpawner.current.BeginSpawn();

                GameManager.current.StartGame();
            }

        }

        //If the ball loses contact with the surface, set game over and make the ball fall down.
       if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            GameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<CameraController>().gameOver = true; //Camera stops following ball because it falls

            PlatformSpawner.current.gameOver = true;

            GameManager.current.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !GameOver)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection ()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else //if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(part, 1f); //We destroy the particles after 1 second to save memory

            ScoreManager.current.DiamondScore(); 
        }
    }
}
