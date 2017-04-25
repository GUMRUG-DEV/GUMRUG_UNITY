using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseScript : MonoBehaviour {

    public overworld Door = new overworld();
    public overworld Hero = new overworld();
	// Use this for initialization
	void Start () {
	Hero.col_Box = GameObject.Find("Gum").GetComponent<BoxCollider2D>();
        Door.col_Box = GameObject.Find("Door").GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Hero.col_Box.bounds.Intersects(Door.col_Box.bounds))
        {
            SceneManager.LoadScene("First Level-House");
        }
        
	}
}
