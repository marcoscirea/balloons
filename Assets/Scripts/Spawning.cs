using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour
{

    public int max = 10;
    public int pooln = 20;
    public GameObject balloon;
    public int maxSpawnTime = 1;
    public int minSpawnTime = 0;
    int timerlength;
    float timerstart;
    ArrayList pool = new ArrayList();
    ArrayList moving = new ArrayList();

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i< pooln; i++)
            pool.Add(Instantiate(balloon));
        SetTimer();
    }
    
    // Update is called once per frame
    void Update()
    {
        CheckForDeads(pool);
        CheckForDeads(moving);

        if (moving.Count < max)
        {
            if (Time.time > timerstart + timerlength)
            {
                GameObject tmp;
                tmp = (GameObject)pool [(int)Random.Range(0, pooln - 1)];
                pool.Remove(tmp);
                moving.Add(tmp);
                tmp.GetComponent<Balloon>().Fly();

                SetTimer();
            }
        }

        if (pool.Count < pooln)
        {
            pool.Add(Instantiate(balloon));
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
