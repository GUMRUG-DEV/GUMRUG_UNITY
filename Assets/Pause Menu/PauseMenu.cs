using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameObject pausePanel;

    public bool isPaused;

	// Use this for initialization
	void Start () {
        isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isPaused)
        {
            PausedGame(true);         
        }
        else
        {
            PausedGame(false);
        }

        if(Input.GetButtonDown ("Cancel"))
        {
            SwitchPause ();
        }
	}
    void PausedGame(bool state)
    {
        if (state)
        {            
            Time.timeScale = 0.0f; //Paused
        }
        else
        {
            Time.timeScale = 1.0f; //Unpaused
            pausePanel.SetActive(false);
        }
        pausePanel.SetActive(state);
    }



    public void SwitchPause()
    {
        if (isPaused)
        {
            isPaused = false; //Changes the value
        }
        else
        {
            isPaused = true;
        }
    }
}
