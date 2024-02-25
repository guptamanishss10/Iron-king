﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mossGiant : enemy, IDamageable
{
    public AudioClip Death1;
    public AudioClip Hit;
    public int Health { get; set; }
    public override void init()
    {
        base.init();
        Health = base.health;
    }
    public override void Movement()
    {
        base.Movement();
    }
    public void Damege()
    {
        if (Isdeath == true)
            return;
        
        if (Health < 1)
        {
            Isdeath = true;
            _anime.SetTrigger("death");
            AudioSource.PlayClipAtPoint(Death1, transform.position, 50f);
            GameObject diamond = Instantiate(DiamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
        else
        {
            AudioSource.PlayClipAtPoint(Hit, transform.position, 50f);
            Health--;
            _anime.SetTrigger("hit");
            ishit = true;
            _anime.SetBool("inCombat", true);
          
        }
    }
}
