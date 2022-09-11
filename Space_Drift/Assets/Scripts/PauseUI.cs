using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private GameManager GM;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }

    public void ShowWindow(bool show)
    {
        animator.SetBool("bPaused", show);
        GM.Pause(!show);
    }
}
