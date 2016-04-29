using UnityEngine;
using System.Collections;

public class nav : MonoBehaviour {
    GameObject dest;
    NavMeshAgent navi;

	// Use this for initialization
	void Start () {
        navi = GetComponent<NavMeshAgent>();
        navi.destination = LocationQueue.getNextPos();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void gameOver()
    {
        System.Random r = new System.Random((int)this.transform.position.x*(int)Time.time);
        if(r.Next(1,100)<= 50)
        {
            navi.destination = LocationQueue.getNextPos();
        }
        else
        {
            navi.destination = new Vector3(0f, 0f, 32.23f);
        }
    }
}
