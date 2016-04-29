using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LocationQueue : MonoBehaviour {
    public static Queue<Transform> q;
	// Use this for initialization
	void Awake () {
        q = new Queue<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public static void store(Transform t)
    {
        q.Enqueue(t);
    }

    public static Vector3 getNextPos()
    {
        if (q.Count > 0)
            return (q.Dequeue().position);
        return new Vector3(0, 0, 0);
    }
}
