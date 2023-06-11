using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class colisiones : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("isJumping", false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isJumping", true);
    }

}
