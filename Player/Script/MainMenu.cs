using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

 
{

    public Text Gems;
    // Start is called before the first frame update
    public void StartButton()
    {
        SceneManager.LoadScene("main");
    }

    // Update is called once per frame
    public void QuitButton()
    {
        Application.Quit();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Main_menu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Thanks");
    }

    public void Start()
    {
        if (nextscean.gems != null)
        {
            Gems.text = nextscean.gems;
        }
       
    }
}
