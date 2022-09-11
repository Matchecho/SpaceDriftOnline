using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager GM;
    private Animator animator;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.isGameOver)
        {
            animator.SetBool("bGameOver", true);
        }
    }

    public void RestartButtonGame()
    {
        animator.SetBool("bGameOver", false);
        GM.GameReloading();
        StartCoroutine(DelayRestart(true, 1.0f));       
    }

    public void WatchAdButtonGame()
    {
        animator.SetBool("bGameOver", false);
        GM.GameReloading();
        StartCoroutine(DelayRestart(false, 1.5f));
    }

    private IEnumerator DelayRestart(bool x, float duration)
    {        
        yield return new WaitForSecondsRealtime(duration);
        if (x)
        {
            GM.GameRestart(0.0f);
        }       
    }

}
