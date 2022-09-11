using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float speedObject = 2.0f;
    
    private GameManager GM;
    private float xBoundary = -3.2f;
    private float timerSpeed = 30.0f;
    private float initialSpeedObject;    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        initialSpeedObject = speedObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.isGameActive)
        {
            if (!GM.isGameOver)
            {
                timerSpeed -= Time.deltaTime;
                if (timerSpeed <= 0.0f)
                {
                    speedObject *= 1.2f;
                    timerSpeed = 30.0f;
                }
            }
            else
            {
                timerSpeed = 30.0f;
                speedObject = initialSpeedObject;
                Destroy(gameObject);
            }
            transform.Translate(Vector2.left * speedObject * Time.deltaTime, Space.World);

        }

        if (transform.position.x < xBoundary)
        {
            Destroy(gameObject);
        }
    }
}
