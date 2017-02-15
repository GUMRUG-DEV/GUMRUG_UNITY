using UnityEngine;
using System.Collections;

public class BootlegBird : MonoBehaviour {

    public overworld Bootlegbird = new overworld();

    [SerializeField]
    float Flyspeed;

    // Use this for initialization
    void Start () {
        Bootlegbird.flyform = gameObject.GetComponent<Transform>();
        Bootlegbird.flyform.position += new Vector3(1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
            Bootlegbird.flyform.position += new Vector3(1, 0, 0);
    }
}
