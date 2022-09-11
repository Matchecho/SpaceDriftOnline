using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardUI : MonoBehaviour
{
    private GameManager GM;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.isGameActive)
        {
            animator.SetBool("bIsGameActive", true);
        }
        else
        {
            animator.SetBool("bIsGameActive", false);
        }
    }
}
