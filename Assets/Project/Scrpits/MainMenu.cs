using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Start Game
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Ultimate()
    {
        SceneManager.LoadScene("Survivor");
    }
    //Exits Game
    public void ExitGame()
    {
        Application.Quit();
    }
    //Adjusts Volume
    public void Volume()
    {

    }
}
