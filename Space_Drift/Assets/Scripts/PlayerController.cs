using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Vector3 StartPos;
    public AudioClip CollectGem;
    public AudioClip CollectO2;
    public AudioClip Jetpack;
    public float JumpForce = 5.0f;

    private GameManager GM;
    private AudioSource AS;
    private Rigidbody2D Rb;
    private bool isPressed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Rb = GetComponent<Rigidbody2D>();
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            Rb.AddForce(Vector2.up * JumpForce * Time.deltaTime, ForceMode2D.Impulse);            
        }

        if(GM.isGameActive)
        {
            Rb.WakeUp();
        }
        else if (!GM.isGameActive)
        {
            Rb.Sleep();
        }
    }

    public void Touch(BaseEventData x)
    {
        isPressed = true;
        AS.PlayOneShot(Jetpack);
    }

    public void Release(BaseEventData y)
    {
        isPressed = false;
        AS.Pause();
    }

    public void Restart()
    {
        isPressed = false;
        gameObject.SetActive(true);
        gameObject.transform.position = StartPos;
        Rb.AddForce(Vector2.up * JumpForce * 35.0f * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        switch (collision.gameObject.tag)
        {
            case "Limit":                
                GM.GameOver();
                gameObject.SetActive(false);
                break;
            case "RedGem":
                GM.Collect(1);
                Destroy(collision.gameObject);
                break;
            case "OrgGem":
                GM.Collect(2);
                Destroy(collision.gameObject);
                break;
            case "YlwGem":
                GM.Collect(5);
                Destroy(collision.gameObject);
                break;
            case "GrnGem":
                GM.Collect(8);
                Destroy(collision.gameObject);
                break;
            case "BluGem":
                GM.Collect(10);
                Destroy(collision.gameObject);
                break;
            case "PrlGem":
                GM.Collect(12);
                Destroy(collision.gameObject);
                break;
            case "PnkGem":
                GM.Collect(15);
                Destroy(collision.gameObject);
                break;
            case "O2":
                GM.AddOxygen();
                Destroy(collision.gameObject);
                break;
            case "Asteroid":
                GM.DepleteOxygen();
                Destroy(collision.gameObject);
                break;
            default:
                break;
        }
        

    }
}
