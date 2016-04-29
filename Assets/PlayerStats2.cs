using UnityEngine;
using System.Collections;

public class PlayerStats2 : MonoBehaviour {

    public string pname;
    public Sprite sprite;
    public int level;
    public int locationX;
    public int locationY;
    public bool playing;
    public int XP = 0;
    public float waitTime = 0f;
    public float playingTime = 0f;

    void OnDestroy()
    {
        DataRecorded.logWaitTime(waitTime);
    }

    void Start()
    {
        PlayerManager.registerPlayer(this.transform);
    }

    void Update()
    {
        if (!playing)
        {
            waitTime += 1f * Time.deltaTime;
        }
        else
        {
            playingTime += 1f * Time.deltaTime;
        }
    }

    public void setNewSprite(Sprite spr)
    {
        sprite = spr;
        GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }

    public void gameStart()
    {

    }

}
