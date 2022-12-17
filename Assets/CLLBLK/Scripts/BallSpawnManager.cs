using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnManager : MonoBehaviour
{
    public bool trig;
    public int spawnId;
    public int ballSpawnCount;
    public GameObject ballPrefab;

    void Start()
    {
        ballPrefab = LineRenderCB.Instance.ballPrefabs[spawnId];
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" && !trig && ballSpawnCount <= 100)
        {
            trig = true;
            ballSpawnCount++;
            GameObject ball = Instantiate(ballPrefab);
            ball.transform.position = this.transform.position;
            ball.GetComponent<BallManager>().ballSpawnManager = this;
        }
    }
}
