using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Reset")) //skulle kunna också checka om spelaren är död //förbättring...
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //https://stackoverflow.com/questions/73056744/press-r-to-restart-unity
        }
        
    }
}
