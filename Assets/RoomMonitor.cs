using UnityEngine;
using System.Collections;
using System;

public class RoomMonitor : MonoBehaviour {

    public int levelDifferential;
    public int avgPing;
    public bool gameStart;
    int gameTimer;
    public int levelTarget;
    public int xTarget;
    public int yTarget;
    int timeOut = 300;
    LineUp2[] spaces;
    System.Random r;

	// Use this for initialization
	void Awake () {
        spaces = GetComponentsInChildren<LineUp2>();
        gameTimer = 0;
        r = new System.Random((int)this.transform.position.x);
    }
	
	// Update is called once per frame
	void Update () {
        GetComponentInChildren<Labeling>().label3();
        if (gameTimer > timeOut)
        {
            gameTimer = 0;
            gameStart = false;
            endGame();
            timeOut = r.Next(300, 600);
        }
        if(!gameStart && roomFull()){
            gameStart = true;
            startGame();
        }
        if(gameStart)
            gameTimer++;
	}

    public bool fillSlot(Transform t)
    {
        if (spaces.Length > 0)
        {
            foreach (LineUp2 l in spaces)
            {
                if (!l.taken)
                {
                    l.spaceTaken(t.gameObject);
                    return true;
                }
            }
        }
        return false;
    }

    public int slotsNeeded()
    {
        int count = 0;
        foreach (LineUp2 l in spaces)
        {
            if (!l.taken)
            {
                count++;
            }
        }
        return count;
    }

    int findLvlDifferential()
    {
        int dif = 0;
        foreach (LineUp2 l in spaces)
        {
            foreach(LineUp2 m in spaces)
            {
                if(l != m)
                {
                    dif += Math.Abs(l.lvl - m.lvl);
                }
            }
        }
        return (dif/(spaces.Length*spaces.Length-1));
    }

    int findPing()
    {
        int dif = 0;
        foreach (LineUp2 l in spaces)
        {
            foreach (LineUp2 m in spaces)
            {
                if (l != m)
                {
                    dif += (int) Vector2.Distance(new Vector2(l.locX, l.locY), new Vector2(m.locX, m.locY));
                }
            }
        }
        return (dif / (spaces.Length * spaces.Length - 1));
    }

    bool roomFull()
    {
        bool full = true;
        foreach (LineUp2 l in spaces)
        {
            full = (full && l.taken);
        }
        return full;
    }

    void startGame()
    {
        foreach (LineUp2 l in spaces)
        {
            l.taken = true;
            l.player.GetComponent<PlayerStats2>().playing = true;
        }
        levelDifferential = findLvlDifferential();
        avgPing = findPing();
        DataRecorded.logPing(avgPing);
        DataRecorded.logLvlDif(levelDifferential);
    }

    void endGame()
    {
        foreach (LineUp2 l in spaces)
        {
            l.taken = false;
            l.player.GetComponent<PlayerStats2>().playing = false;
            if (r.Next(0, 100) > 50)
                PlayerManager.registerPlayer(l.player.transform);
            else
                Destroy(l.player);
        }
        RoomManager.registerRoom(this);
        
    }
}
