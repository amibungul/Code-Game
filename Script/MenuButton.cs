using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuButton : MonoBehaviour
{
    public CanvasGroup main, game, pause, over;
    public bool playing, retry, ad;
    public int fuel, health, multiplier;
    public TextMeshProUGUI fueltext, healthtext;
    // Start is called before the first frame update
    void Start()
    {
        if (retry == true)
        {
            StartButton();
            retry = false;
        }
        InvokeRepeating("GetFaster", 30, 30);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        fuel = int.Parse(fueltext.text);
        health = int.Parse(healthtext.text);
        if (fuel <= 0 || health <= 0)
        {
            Time.timeScale = 0;

            over.alpha = 1;
            over.interactable = true;
            over.blocksRaycasts = true;

            game.alpha = 0;
            game.interactable = false;
            game.blocksRaycasts = false;

            playing = false;
        }
    }

    public void StartButton()
    {
        fuel = int.Parse(fueltext.text);
        health = int.Parse(healthtext.text);
        main.alpha = 0;
        main.interactable = false;
        main.blocksRaycasts = false;

        game.alpha = 1;
        game.interactable = true;
        game.blocksRaycasts = true;

        playing = true;

    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("start");
        
        AudioListener.pause = false;
    }

    public void Paused()
    {
        game.alpha = 0;
        game.interactable = false;
        game.blocksRaycasts = false;

        pause.alpha = 1;
        pause.interactable = true;
        pause.blocksRaycasts = true;

        playing = false;

        AudioListener.pause = true;

        Time.timeScale = 0;
    }

    public void Resumed()
    {
        game.alpha = 1;
        game.interactable = true;
        game.blocksRaycasts = true;

        pause.alpha = 0;
        pause.interactable = false;
        pause.blocksRaycasts = false;

        AudioListener.pause = false;

        playing = true;

        Time.timeScale = 1;
    }

    public void Retry()
    {
        retry = true;
        ToMainMenu();
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void GetFaster()
    {
        multiplier += 1;
    }
}
