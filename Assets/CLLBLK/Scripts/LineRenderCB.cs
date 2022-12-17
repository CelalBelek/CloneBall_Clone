using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LineRenderCB : MonoBehaviour
{
    public static LineRenderCB Instance;
    void Awake() => Instance = this;

    LineRenderer _linerenderer;
    Plane rayPlane;
    Vector3 newPosition;

    [SerializeField] Transform[] targetPointTransform;
    [SerializeField] Transform lineEndTarget;
    [SerializeField] GameObject moveObject;

    public BallSpawnManager[] ballSpawnManager;
    public GameObject[] ballPrefabs;
    public int ballCount;
    [SerializeField] float speed;
    
    void Start()
    {
        _linerenderer = GetComponent<LineRenderer>();   
        _linerenderer.positionCount = targetPointTransform.Length;

        rayPlane = new Plane(Vector3.up, targetPointTransform[0].position);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (rayPlane.Raycast(ray, out float enter))
            {
                newPosition = ray.GetPoint(enter);
                moveObject.transform.position = newPosition;
                moveObject.transform.LookAt(this.transform);
                this.transform.rotation = Quaternion.Euler(0, moveObject.transform.eulerAngles.y + 90, 0);
                targetPointTransform[1].transform.position = Vector3.MoveTowards(transform.position, lineEndTarget.position, 10f);
            }
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (rayPlane.Raycast(ray, out float enter))
            {
                newPosition = ray.GetPoint(enter);
                moveObject.transform.position = newPosition;
                moveObject.transform.LookAt(this.transform);
                this.transform.rotation = Quaternion.Euler(0, moveObject.transform.eulerAngles.y + 90, 0);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            targetPointTransform[1].transform.position = Vector3.MoveTowards(lineEndTarget.position, transform.position, 10f);
            BallSpawn();
        }

        for (int i = 0; i < targetPointTransform.Length; i++)
        {
            _linerenderer.SetPosition(i, targetPointTransform[i].position);
        }
    }

    private void BallSpawn()
    {
        GameObject ball = Instantiate(ballPrefabs[0]);
        ball.transform.position = new Vector3(0, 0, 0);
        ball.GetComponent<Rigidbody>().velocity = ball.transform.TransformDirection(moveObject.transform.forward * 10); 
    }
}
