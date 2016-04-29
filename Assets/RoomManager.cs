using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour {
    public static List<RoomMonitor> rooms;

    float x = -10;
    float z = 8;
    public GameObject roomNeo;
    int calcTime = 10;
    int counter = 0;
    bool done = false;

    // Use this for initialization
    void Start () {
        rooms = new List<RoomMonitor>();
	}
	
	// Update is called once per frame
	void Update () {
       fifoHandle();
       /*if(counter > 100)
        {
            levelHandle();
            counter = 0;
        }
        counter++;*/
	}

    void fifoHandle()
    {
        if (PlayerManager.players.Count > 0)
        {
            if (rooms.Count == 0)
            {
                GameObject temp = (GameObject)Instantiate(roomNeo, new Vector3(x, 0f, z), new Quaternion());
                registerRoom(temp.GetComponentInChildren<RoomMonitor>());
                z -= 8;
                if(z < -8f)
                {
                    x -= 6f;
                    z = 8f;
                }
            }
            rooms[0].fillSlot(PlayerManager.players[0]);
            PlayerManager.deregisterPlayer(PlayerManager.players[0]);
            if(rooms[0].slotsNeeded() == 0)
            {
                removeRoom(rooms[0]);
            }

        }
    }
    
    void levelHandle()
    {
        if (PlayerManager.players.Count > 0)
             {
                 int curLevel = PlayerManager.players[0].gameObject.GetComponent<PlayerStats2>().level;
                 bool placed = false;
                 if (rooms.Count == 0)
                 {
                     GameObject newRoom = createRoom();
                     newRoom.GetComponent<RoomMonitor>().fillSlot(PlayerManager.players[0]);
                     newRoom.GetComponent<RoomMonitor>().levelTarget = curLevel;
                     PlayerManager.deregisterPlayer(PlayerManager.players[0]);
                     placed = true;
                 }



          if (!placed) {
                foreach (RoomMonitor r in rooms.ToArray())
                {
                    if (r.slotsNeeded() == 4)
                    {
                        r.fillSlot(PlayerManager.players[0]);
                        r.levelTarget = curLevel;
                        PlayerManager.deregisterPlayer(PlayerManager.players[0]);
                        placed = true;
                        break;
                    }
                    else if ((r.levelTarget - curLevel) < 5 && (r.levelTarget - curLevel) > -5)
                    {
                        r.fillSlot(PlayerManager.players[0]);
                        PlayerManager.deregisterPlayer(PlayerManager.players[0]);
                        placed = true;
                        if (r.slotsNeeded() == 0)
                        {
                            removeRoom(r);
                        }
                    }
                }

                    }
                    if (!placed)
                    {
                        GameObject newRoom = createRoom();
                        newRoom.GetComponent<RoomMonitor>().fillSlot(PlayerManager.players[0]);
                        newRoom.GetComponent<RoomMonitor>().levelTarget = curLevel;
                        PlayerManager.deregisterPlayer(PlayerManager.players[0]);

                    }

               
        }
    }

    void lagHandle()
    {
        if (PlayerManager.players.Count > 0)
        {
            int curLocX = PlayerManager.players[0].gameObject.GetComponent<PlayerStats2>().locationX;
            int curLocY = PlayerManager.players[0].gameObject.GetComponent<PlayerStats2>().locationY;
            bool placed = false;
            if (rooms.Count == 0)
            {
                GameObject newRoom = createRoom();
                newRoom.GetComponent<RoomMonitor>().fillSlot(PlayerManager.players[0]);
                newRoom.GetComponent<RoomMonitor>().xTarget = curLocX;
                newRoom.GetComponent<RoomMonitor>().yTarget = curLocY;
                PlayerManager.deregisterPlayer(PlayerManager.players[0]);
                placed = true;
            }



            if (!placed)
            {
                foreach (RoomMonitor r in rooms.ToArray())
                {
                    float latency = Vector2.Distance(new Vector2(r.xTarget, r.yTarget), new Vector2(curLocX, curLocY));
                    if (r.slotsNeeded() == 4)
                    {
                        r.fillSlot(PlayerManager.players[0]);
                        r.xTarget = curLocX;
                        r.yTarget = curLocY;
                        PlayerManager.deregisterPlayer(PlayerManager.players[0]);
                        placed = true;
                        break;
                    }
                    else if (latency < 30)
                    {
                        r.fillSlot(PlayerManager.players[0]);
                        PlayerManager.deregisterPlayer(PlayerManager.players[0]);
                        placed = true;
                        if (r.slotsNeeded() == 0)
                        {
                            removeRoom(r);
                        }
                    }
                }

            }
            if (!placed)
            {
                GameObject newRoom = createRoom();
                newRoom.GetComponent<RoomMonitor>().fillSlot(PlayerManager.players[0]);
                newRoom.GetComponent<RoomMonitor>().xTarget = curLocX;
                newRoom.GetComponent<RoomMonitor>().yTarget = curLocY;
                PlayerManager.deregisterPlayer(PlayerManager.players[0]);

            }


        }
    }

    void lagPlusLevelHandle()
    {
        if (PlayerManager.players.Count > 0)
        {
            int curLocX = PlayerManager.players[0].gameObject.GetComponent<PlayerStats2>().locationX;
            int curLocY = PlayerManager.players[0].gameObject.GetComponent<PlayerStats2>().locationY;
            int curLevel = PlayerManager.players[0].gameObject.GetComponent<PlayerStats2>().level;
            bool placed = false;
            if (rooms.Count == 0)
            {
                GameObject newRoom = createRoom();
                newRoom.GetComponent<RoomMonitor>().fillSlot(PlayerManager.players[0]);
                newRoom.GetComponent<RoomMonitor>().levelTarget = curLevel;
                newRoom.GetComponent<RoomMonitor>().xTarget = curLocX;
                newRoom.GetComponent<RoomMonitor>().yTarget = curLocY;
                PlayerManager.deregisterPlayer(PlayerManager.players[0]);
                placed = true;
            }



            if (!placed)
            {
                foreach (RoomMonitor r in rooms.ToArray())
                {
                    float latency = Vector2.Distance(new Vector2(r.xTarget, r.yTarget), new Vector2(curLocX, curLocY));
                    if (r.slotsNeeded() == 4)
                    {
                        r.fillSlot(PlayerManager.players[0]);
                        r.xTarget = curLocX;
                        r.yTarget = curLocY;
                        PlayerManager.deregisterPlayer(PlayerManager.players[0]);
                        placed = true;
                        break;
                    }
                    else if (latency < 30 && (r.levelTarget - curLevel) < 5 && (r.levelTarget - curLevel) > -5)
                    {
                        r.fillSlot(PlayerManager.players[0]);
                        PlayerManager.deregisterPlayer(PlayerManager.players[0]);
                        placed = true;
                        if (r.slotsNeeded() == 0)
                        {
                            removeRoom(r);
                        }
                    }
                }

            }
            if (!placed)
            {
                GameObject newRoom = createRoom();
                newRoom.GetComponent<RoomMonitor>().fillSlot(PlayerManager.players[0]);
                newRoom.GetComponent<RoomMonitor>().xTarget = curLocX;
                newRoom.GetComponent<RoomMonitor>().yTarget = curLocY;
                newRoom.GetComponent<RoomMonitor>().levelTarget = curLevel;
                PlayerManager.deregisterPlayer(PlayerManager.players[0]);

            }


        }
    }

    public static void registerRoom(RoomMonitor m)
    {
        rooms.Add(m);
    }
    GameObject createRoom()
    {
        GameObject temp = (GameObject)Instantiate(roomNeo, new Vector3(x, 0f, z), new Quaternion());
        registerRoom(temp.GetComponentInChildren<RoomMonitor>());
        z -= 8;
        if (z < -8f)
        {
            x -= 6f;
            z = 8f;
        }
        return temp;
    }

    public static void removeRoom(RoomMonitor m)
    {
        rooms.Remove(m);
    }
}
