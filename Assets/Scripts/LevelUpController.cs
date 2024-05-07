using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class LevelUpController : MonoBehaviour
{
    PlayerController playerScript;

    Button DamageButton;

    Button FireRateButton;

    Button SpeedButton;
    

    // Start is called before the first frame update
    void Start()
    {
        CreateLevelUpScreen();
        HideLevelScreen();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateLevelUpScreen()
    {
        //get buttons clicked.
        DamageButton = GameObject.FindGameObjectWithTag("DamageButton").GetComponent<Button>();
        FireRateButton = GameObject.FindGameObjectWithTag("FireRateButton").GetComponent<Button>();
        SpeedButton = GameObject.FindGameObjectWithTag("SpeedButton").GetComponent<Button>();

        //Set actions
        DamageButton.onClick.AddListener(DamageIncrease);
        FireRateButton.onClick.AddListener(FireRateIncrease);
        SpeedButton.onClick.AddListener(SpeedIncrease);
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

