using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI O2_text;
    public TextMeshProUGUI GemText;
    public TextMeshProUGUI GemsCollectedText;
    public AudioClip Theme;
    public AudioClip CollectGem;
    public AudioClip CollectO2;
    public AudioClip Damage;
    public AudioClip Gameover;
    public AudioClip Play;
    public const float StartO2 = 100.0f;
    public bool isGameActive = true;
    public bool isGameOver = false;

    private SpawnManager SMGems;
    private SpawnManager SMO2;
    private SpawnManager SMAsteroids;
    private PlayerController PC;
    private AudioSource AS;
    private int GemStonesScore = 0;
    private float O2 = 100.0f;

    void Start()
    {
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
        SMGems = GameObject.Find("SpawnManagerGems").GetComponent<SpawnManager>();
        SMO2 = GameObject.Find("SpawnManagerO2").GetComponent<SpawnManager>();
        SMAsteroids = GameObject.Find("SpawnManagerAsteroids").GetComponent<SpawnManager>();
        AS = GetComponent<AudioSource>();
        isGameActive = false;
        AS.PlayOneShot(Theme);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameActive)
        {
            if (!AS.isPlaying && !isGameOver)
            {
                AS.PlayOneShot(Theme);
            }
            O2 -= Time.deltaTime;
            O2_text.text = Mathf.Ceil(O2).ToString();
            
            if (O2 <= 0)
            {
                GameOver();
            }
        }
        else if (isGameOver)
        {
            if (!AS.isPlaying)
            {
                AS.PlayOneShot(Gameover);
            }
            
        }
    }

    public void StartGame()
    {
        AdsManager.Instance.PlayBanner();

        isGameActive = true;
        GemStonesScore = 0;
        O2 = StartO2;
        GemText.text = GemStonesScore.ToString();
        O2_text.text = O2.ToString();

        SMGems.Spawnning();
        SMO2.Spawnning();
        SMAsteroids.Spawnning();
        AS.PlayOneShot(Play);
    }
    public void Pause(bool paused)
    {
        isGameActive = paused;
    }

    public void GameOver()
    {
        AdsManager.Instance.PlayInterstitial();
        SMO2.CancelInvoke();
        SMGems.CancelInvoke();
        SMAsteroids.CancelInvoke();
        isGameActive = false;
        isGameOver = true;
        GemsCollectedText.text = "Gems Colledted: " + GemStonesScore.ToString();
        AS.Stop();
        AS.PlayOneShot(Gameover);
    }

    public void GameReloading()
    {
        isGameActive = true;
        isGameOver = false;
    }

    public void GameRestart(float r)
    {
        GemStonesScore = 0;
        O2 = StartO2 + r;
        GemText.text = GemStonesScore.ToString();
        O2_text.text = O2.ToString();
        GemsCollectedText.text = "Gems Collected: " + GemStonesScore.ToString();
        PC.Restart();
        SMO2.Spawnning();
        SMGems.Spawnning();
        SMAsteroids.Spawnning();
        AS.PlayOneShot(Play);
        AS.Stop();
        AS.PlayOneShot(Theme);
    }

    public void Collect(int value)
    {
        GemStonesScore += value;       
        GemText.text = GemStonesScore.ToString();
        AS.PlayOneShot(CollectGem);
    }

    public void AddOxygen()
    {
        O2 += 25;
        O2_text.text = O2.ToString();
        AS.PlayOneShot(CollectO2);
    }

    public void DepleteOxygen()
    {
        O2 -= 20;
        O2_text.text = O2.ToString();
        AS.PlayOneShot(Damage);
    }

    public void WatcAdRewarded()
    {
        AdsManager.Instance.PlayRewarded(RestartWithReward);
    }

    public void RestartWithReward()
    {
        GameRestart(25.0f);
    }
}
