using UnityEngine;
using System.Collections;

public class LineUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        needPlayer();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void needPlayer()
    {
        LocationQueue.store(this.gameObject.transform);
    }
}
