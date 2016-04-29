using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DataRecorded : MonoBehaviour {

    public static List<float> waitTimes = new List<float>();
    public static List<float> playTimes = new List<float>();
    public static List<float> playToWaitRatios= new List<float>();
    public static List<float> levelDifferential = new List<float>();
    public static List<float> latency = new List<float>();
    public int timeStep = 0;
    public int nextRecordStep = 100;
    static StreamWriter sw = new StreamWriter("D:\\Game Projects\\ModelingAndSim\\Network test\\Assets\\Results.txt");




    // Use this for initialization
    void Start () {
	
	}

	
	// Update is called once per frame
	void Update () {
        timeStep += 1;
        if (timeStep >= nextRecordStep)
        {
            nextRecordStep += 100;
            recordData();
        }
	}

    void OnDestroy()
    {
        recordData();
        sw.Close();
    }

    void recordData()
    {
        sw.WriteLine("Time: " + timeStep);
        if(waitTimes.Count != 0)
        {
            sw.WriteLine("Average Wait Time: " + average(waitTimes));
        }
        if (playTimes.Count != 0)
        {
            sw.WriteLine("Average Play Time: " + average(playTimes));
        }
        if (playToWaitRatios.Count != 0)
        {
            sw.WriteLine("Average Play to Wait Ratio: " + average(playToWaitRatios));
        }
        if (levelDifferential.Count != 0)
        {
            sw.WriteLine("Average Level Differential: " + average(levelDifferential));
        }
        if (latency.Count != 0)
        {
            sw.WriteLine("Average Latency Time: " + average(latency));
        }

    }

    float average(List<float> fs)
    {
        float avg = 0;
        foreach(float f in fs)
        {
            avg += f;
        }
        avg = avg / fs.Count;
        return avg;
    }

    public static void logPing(int ping)
    {
        latency.Add(ping);
    }

    public static void logLvlDif(int dif)
    {
        levelDifferential.Add(dif);
    }

    public static void logWaitTime(float f)
    {
        waitTimes.Add(f);
    }
}
