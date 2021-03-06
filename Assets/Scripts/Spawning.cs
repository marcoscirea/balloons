﻿using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour
{

    public int max = 5; 
    public int pooln = 20; 
    public int evilpooln = 5; 
    public GameObject balloon;
    public GameObject evil;
    public float maxSpawnTime = 1f;
    public float minSpawnTime = 0f;
    float timerlength;
    float timerstart;
    ArrayList pool = new ArrayList();
    ArrayList moving = new ArrayList();
    ArrayList evilpool = new ArrayList();
    public float evilChance = 0.01f;

    //level related variables
    public int newlevel = 5;
    float levelStartTime;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i< pooln; i++)
            pool.Add(Instantiate(balloon));
        for (int i = 0; i< evilpooln; i++)
            evilpool.Add(Instantiate(evil));
        SetTimer();

        levelStartTime = Time.time;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time > levelStartTime + newlevel)
        {
            levelStartTime = Time.time;
            max++;
            evilChance+=0.01f;
            if (maxSpawnTime>0.03f)
                maxSpawnTime-=0.03f;
            Debug.Log("new level, max="+max+ " evil="+evilChance+ " maxSpawnTime="+maxSpawnTime);
        }


        CheckForDeads(pool);
        CheckForDeads(moving);
        CheckForDeads(evilpool);

        if (moving.Count < max)
        {
            if (Time.time > timerstart + timerlength)
            {
                float rand = Random.Range(0f,1f);
                if (rand < evilChance){
                    GameObject tmp;
                    tmp = (GameObject)evilpool [(int)Random.Range(0, evilpooln - 1)];
                    evilpool.Remove(tmp);
                    moving.Add(tmp);
                    tmp.GetComponent<EvilBalloon>().Fly();
                }
                else {
                    GameObject tmp;
                    tmp = (GameObject)pool [(int)Random.Range(0, pooln - 1)];
                    pool.Remove(tmp);
                    moving.Add(tmp);
                    tmp.GetComponent<Balloon>().Fly();
                }

                SetTimer();
            }
        }

        if (pool.Count < pooln)
        {
            pool.Add(Instantiate(balloon));
        }
        if (evilpool.Count < evilpooln)
        {
            evilpool.Add(Instantiate(evil));
        }
    }

    void CheckForDeads(ArrayList list)
    {
        ArrayList dead = new ArrayList();
        foreach (GameObject g in list)
        {
            if (g == null)
                dead.Add(g);
        }
        foreach (GameObject g in dead)
        {
            list.Remove(g);
        }
    }

    void SetTimer()
    {
        timerstart = Time.time;
        timerlength = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
