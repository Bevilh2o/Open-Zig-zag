using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Diamond;
    Vector3 LastPosition;
    Vector3 pos;
    float Size;
    public bool gameOver;
    public static PlatformSpawner current;



    void Awake()
    {
        current = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        LastPosition = Platform.transform.position;
        Size = Platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            PlatformSpawn();
        }

        //BeginSpawn();
    }

    public void BeginSpawn()
    {
        InvokeRepeating("PlatformSpawn", 1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            CancelInvoke("PlatformSpawn");
    }

    void PlatformSpawn()
    {
        int rand = Random.Range(0, 6);

        if (rand < 3)
            SpawnX();
        else
            SpawnZ();
    }

    void CreateDiamond()
    {
        int rand = Random.Range(0, 4);
        if (rand < 1)
            Instantiate(Diamond, new Vector3(pos.x, pos.y + 1f, pos.z), Diamond.transform.rotation);
    }

    void SpawnX()
    {
        pos = LastPosition;
        pos.x += Size;
        LastPosition = pos;
        Instantiate(Platform, pos, Quaternion.identity);
        CreateDiamond();
    }

    void SpawnZ()
    {
        pos = LastPosition;
        pos.z += Size;
        LastPosition = pos;
        Instantiate(Platform, pos, Quaternion.identity);
        CreateDiamond();

    }
}
