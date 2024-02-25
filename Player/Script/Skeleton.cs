using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : enemy, IDamageable
{
    public AudioClip Death1;
   /* public AudioClip Move;*/
    public AudioClip Hit;
    public int Health { get; set; }
    public override void init()
    {
        base.init();
        Health = base.health;
    }
    public override void Movement()
    {
        //base.Movement();
        /*  AudioSource.PlayClipAtPoint(Move, transform.position, 50f);*/

        if (_switch == PointA.position)
        {
            _mossSprite.flipX = true;
        }
        else
        {
            _mossSprite.flipX = false;
        }
        if (transform.position == PointA.position)
        {
            _switch = PointB.position;
            _anime.SetTrigger("idle");
        }
        else if (transform.position == PointB.position)
        {
            _switch = PointA.position;
            _anime.SetTrigger("idle");
        }
        if (ishit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switch, speed * Time.deltaTime);

        }

        float distance = Vector3.Distance(Player.transform.localPosition, transform.localPosition);
        /*Debug.Log(distance);*/
        if (distance > 10.0f)
        {
            ishit = false;
            _anime.SetBool("inCombat", false);
        }

        Vector3 Direction = Player.transform.localPosition - transform.localPosition;
        Debug.Log(Direction.x);
/*        Debug.Log(Player.transform.localPosition);
        Debug.Log(transform.localPosition);*/
        if (Direction.x > 0 && _anime.GetBool("inCombat") == true)
        {
            _mossSprite.flipX = false;
        }
        else if (Direction.x < 0 && _anime.GetBool("inCombat") == true)
        {
            _mossSprite.flipX = true;
        }

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
