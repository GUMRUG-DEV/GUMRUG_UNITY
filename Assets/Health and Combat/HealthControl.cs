using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthControl : MonoBehaviour {
    public Image healthBar;
    public float health; //between 0 - 100
    public GameObject restartDialog;

	// Use this for initialization
	void Start () {
        ShowRestartDialog(false);
	}
	
	// Update is called once per frame
	void Update () {
        checkHealth();
	}


    void checkHealth()
    {
        healthBar.rectTransform.localScale = new Vector2(health / 100, healthBar.rectTransform.localScale.y);
            if (health <= 0.0f)
            //Restart Script
        {
            ShowRestartDialog(true);
        }
    }
    public void SubtractHealth(float amount)
    {
        if(health - amount < 0.0f)
        {
            health = 0.0f;
        }
        else
        {
            health -= amount;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("ENEMY"))
        {           
            {
                SubtractHealth(5.0f);           
            }
        }
        else if (other.collider.CompareTag("LIFE"))
        {
            AddHealth(5.0f);
        }
    }
    public void AddHealth(float amount)
    {
        if(health + amount > 100.0f)
        {
            health = 100.0f;
        }
        else
        {
            health += amount;
        }
    }
    public void ShowRestartDialog(bool c)
    {
        if (c)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        restartDialog.SetActive(c);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Health and Combat/Health and Combat");
    }
}
