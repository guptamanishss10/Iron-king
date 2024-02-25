using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : enemy, IDamageable
{
    public GameObject AcidEffectPrefab;
    public AudioClip Death1;
    /*public AudioClip Hit;*/
    public AudioClip Attack1;
    public int Health { get; set; }


    public override void init()
    {
        base.init();
        Health = base.health;
    }
    public override void Update()
    {
        Movement();
    }
    public void Damege()
    {
        if (Isdeath == true)
            return;
        Health--;
        if (Health < 1)
        {
            Isdeath = true;
            _anime.SetTrigger("death");
            AudioSource.PlayClipAtPoint(Death1, transform.position, 50f);
            GameObject diamond = Instantiate(DiamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
       /* else
        {
            AudioSource.PlayClipAtPoint(Hit, transform.position, 50f);
        }*/
    }
    public override void Movement()
    {
        /*base.Movement();*/
    }
    public void Attack()
    {
        Instantiate(AcidEffectPrefab, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(Attack1, transform.position, 50f);
    }
}
