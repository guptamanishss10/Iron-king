using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextscean : MainMenu
{

    public static string gems;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            player Player1 = other.GetComponent<player>();
            if (Player1 != null)
            {
                SceneManager.LoadScene("Thanks");
            }

        }

    }
}
