using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    bool gameIsOn = true;
    bool gameIsPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameIsOn)
        {
            StartLevelAgain();
        }

        TogglePause();
    }

    public bool IsGamePaused()
    {
        return gameIsPaused;
    }

    public bool IsGameOn()
    {
        return gameIsOn;
    }

    public void TogglePause()
    {
        if(Input.GetButtonDown("Submit"))
        {
            gameIsPaused = gameIsPaused == true ? false : true;
            Debug.Log(gameIsPaused);
        }
    }

    public void StartLevelAgain()
    {
        //Do stuff kun pelaaja kuolee
    }
}
