using UnityEngine;
using System.Collections;

public class PlayerSpawner1 : MonoBehaviour {

    public GameObject it;
    int counter = 0;
    public Sprite[] sprites;
    public string[] names;
    System.Random r;
    int spawnTime;
    public int lowerBoundSpawnTime = 10;
    public int upperBoundSpawnTime = 60;
	// Use this for initialization
	void Start () {
        r = new System.Random();
        r = new System.Random(r.Next((int)this.transform.position.x, 9999));
        r = new System.Random(r.Next((int)this.transform.position.y, 9999));
        spawnTime = r.Next(lowerBoundSpawnTime, upperBoundSpawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	    if (counter > spawnTime)
        {
            GameObject temp = Instantiate(it, this.transform.position, new Quaternion()) as GameObject;
            temp.GetComponent<PlayerStats2>().pname = names[r.Next(0, names.Length)];
            temp.GetComponent<PlayerStats2>().level = r.Next(0,50);
            temp.GetComponent<PlayerStats2>().locationX = r.Next(0,100);
            temp.GetComponent<PlayerStats2>().locationY = r.Next(0, 100);
            temp.GetComponent<PlayerStats2>().setNewSprite(sprites[r.Next(0,sprites.Length)]);
            temp.GetComponentInChildren<Labeling>().label2();
            counter = 0;
            spawnTime = r.Next(lowerBoundSpawnTime, upperBoundSpawnTime);
        }
        else
        {
            counter++;
        }
	}
}
