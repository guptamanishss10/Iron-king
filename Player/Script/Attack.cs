﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _candamage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
/*        Debug.Log("hit:" + other.name);
*/        IDamageable hit = other.GetComponent<IDamageable>();
        if (hit != null)
        {
            if (_candamage == true)
            {
                hit.Damege();
                _candamage = false;
                StartCoroutine(ResetDamage());
            }
           
        }


    }
    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _candamage = true;
    }
}
