using UnityEngine;
using System.Collections;

public class Labeling : MonoBehaviour {
    
	
	public void label () {
        TextMesh txt = GetComponent<TextMesh>();
        PlayerStats p = GetComponentInParent<PlayerStats>();
        txt.text = "Username: " + p.pname + "\nLevel: " + p.level + "\nLatency: " + p.latency;
	}

    public void label2()
    {
        TextMesh txt = GetComponent<TextMesh>();
        PlayerStats2 p = GetComponentInParent<PlayerStats2>();
        txt.text = "Username: " + p.pname + "\nLevel: " + p.level + "\nLocation: (" + p.locationX + ", " + p.locationY+")";
    }

    public void label3()
    {
        TextMesh txt = GetComponent<TextMesh>();
        RoomMonitor r = GetComponentInParent<RoomMonitor>();
        int slots = r.slotsNeeded();
        if(slots > 0)
        {
            txt.text = "\nNot Full\nNeed " + slots + " more";
        }
        else
        {
            txt.text = "\nLevel Differential: " + r.levelDifferential + "\nLatency: " + r.avgPing;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
