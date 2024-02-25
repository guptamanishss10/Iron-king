﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
/*    private Animator _Swardanim;
*/    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }
    public void Jump(bool Jumping)

    {
        _anim.SetBool("jumping", Jumping);

    }
    public void Attack()
    {
        _anim.SetTrigger("attack");
/*        _Swardanim.SetTrigger("swardAnima");
*/    }
    public void Death()
    {
        _anim.SetTrigger("death");
        Invoke("GameOver", 4f);

    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Hit()
    {
        _anim.SetTrigger("playerhit");
    }
}
