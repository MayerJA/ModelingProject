using UnityEngine;
using System.Collections;

public class PlayerStats: MonoBehaviour{
    public string pname;
    public Sprite sprite;
    public int level;
    public int latency;

    void Start()
    {
        System.Random r = new System.Random();
        pname = "Test";
        level = r.Next(1, 50);
        latency = r.Next(0, 999);
    }

    public void setNewSprite(Sprite spr)
    {
        sprite = spr;
        GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }
	
}
