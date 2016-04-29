using UnityEngine;
using System.Collections;

public class LineUp2 : MonoBehaviour {

    public bool taken;
    public int lvl;
    public int locX;
    public int locY;
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void spaceTaken(GameObject g)
    {
        g.transform.position = this.transform.position;
        player = g;
        taken = true;
        lvl = g.GetComponent<PlayerStats2>().level;
        locX = g.GetComponent<PlayerStats2>().locationX;
        locY = g.GetComponent<PlayerStats2>().locationY;
    }
}
