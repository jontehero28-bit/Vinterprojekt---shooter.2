using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class LevelUpController : MonoBehaviour
{
    PlayerController playerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        HideLevelScreen();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLevelScreen()
    {
        this.gameObject.SetActive(true);
        PauseGame();
    }

    public void HideLevelScreen()
    {
        this.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }
    
    

    public void DamageIncrease()
    {
        HideLevelScreen();
        UnpauseGame();
        playerScript.PlayerDamage += 5;
    }

    public void FireRateIncrease()
    {
        HideLevelScreen();
        UnpauseGame();
        playerScript.GunCooldownTime -= 1;
    }

    public void SpeedIncrease() 
    {
        HideLevelScreen();
        UnpauseGame();
        playerScript.Speed++;
    }
}

