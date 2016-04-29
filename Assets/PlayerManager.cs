using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public static List<Transform> players;


	// Use this for initialization
	void Start()
    {
        players = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = 4.5f;
        float z = 4.5f;
        foreach(Transform p in players)
        {
            p.position = new Vector3(x, 1f, z);
            z--;
            if(z < -4.5f)
            {
                x--;
                z = 4.5f;
            }
        }
    }

    public static void registerPlayer(Transform t)
    {
        players.Add(t);
    }

    public static void deregisterPlayer(Transform t)
    {
        players.Remove(t);
    }
}
