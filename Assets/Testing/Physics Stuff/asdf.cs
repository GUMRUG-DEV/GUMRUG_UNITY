using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdf : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            System.Threading.Thread.Sleep(100);
            Instantiate(GameObject.Find("Clone"), new Vector2 (3, 10), Quaternion.identity);
            Instantiate(GameObject.Find("Clone"), new Vector2(3.1f, 10), Quaternion.identity);
            Instantiate(GameObject.Find("Clone"), new Vector2(3.2f, 10), Quaternion.identity);
            Debug.Log("Click.");
        }

    }
}
