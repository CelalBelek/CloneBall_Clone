using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public bool trig;
    public BallSpawnManager ballSpawnManager;

    void Start()
    {

    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" && !trig && ballSpawnManager.ballSpawnCount <= 100)
        {
            trig = true;
            ballSpawnManager.ballSpawnCount++;
            GameObject ball = Instantiate(ballSpawnManager.ballPrefab);
            ball.transform.position = this.transform.position;
            ball.GetComponent<BallManager>().ballSpawnManager = ballSpawnManager;
        }
    }
}
