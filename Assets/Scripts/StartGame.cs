using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{

    public float[] changes;
    public Vector3[] shots;
    public float[] shotSizes;
    int currentScene = 0;
    bool first = true;
    Vector3 direction = Vector3.zero;
    bool full = false;
    Vector3 startingPosition;
    float startingSize;
    Quaternion startingRotation;
    GUIText skip;
    bool skipping = false;
    ArrayList usedTouches = new ArrayList();
    bool timer = true;
    float timerStart;
    float timerLength= 5f;

    // Use this for initialization
    void Start()
    {
        startingSize = camera.orthographicSize;
        startingPosition = transform.position;
        startingRotation = transform.rotation;
        audio.Play();

        skip = GameObject.Find("Skip").guiText;
        skipping = false;
        timerStart = Time.time;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!full)
        {
            if (currentScene < changes.Length)
            {
                if (audio.time >= changes [currentScene])
                {
                    if (currentScene == 0)
                    {
                        if (GameObject.Find("Black") != null)
                            GameObject.Find("Black").SetActive(false);
                        GameObject.Find("TitleText").renderer.enabled = true;
                    }
                    //Debug.Log(audio.time + " " + changes [currentScene]);
                    transform.position = shots [currentScene];
                    camera.orthographicSize = shotSizes [currentScene];

                    if (!first)
                    {
                        if (currentScene % 2 == 0)
                        {
                            transform.rotation = startingRotation;
                            transform.Rotate(new Vector3(0, 0, 20));
                        } else
                        {
                            transform.rotation = startingRotation;
                            transform.Rotate(new Vector3(0, 0, -20));
                        }
                    }

                    currentScene++;
                }
            } else
            {
                if (first)
                {
                    //rewind shots, music starts at 18
                    for (int tmp = 0; tmp<changes.Length; tmp++)
                    {
                        if (tmp == 4 || tmp == 5 || tmp == 6)
                            changes [tmp] += 9.3f;
                        else
                            changes [tmp] += 8.8f;
                    }
                    currentScene = 0;
                    first = false;
                }
                if (audio.time > 26.8)
                {
                    transform.position = startingPosition;
                    camera.orthographicSize = startingSize;
                    transform.rotation = startingRotation;
                    skip.enabled = false;
                    full = true;
                }
            }
        } else
        {
            //Debug.Log(Vector3.Distance(transform.position, startingPosition));
            if (direction == Vector3.zero || Vector3.Distance(transform.position, startingPosition) > 0.1f)
            {
                direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
            }
            transform.position += direction * Time.deltaTime * 0.1f;
        }

        if (!timer)
        {
            int i = 0;
            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began && !usedTouches.Contains(Input.GetTouch(i).fingerId))
                {
                    usedTouches.Add(Input.GetTouch(i).fingerId);
                    if (full)
                        Application.LoadLevel("Game");
                    else
                    {
                        if (!skipping)
                        {
                            skip.enabled = true;
                            skipping = true;
                        } else
                        {
                            full = true;
                            if (currentScene == 0)
                            {
                                if (GameObject.Find("Black") != null)
                                    GameObject.Find("Black").SetActive(false);
                                GameObject.Find("TitleText").renderer.enabled = true;
                            }
                            transform.position = startingPosition;
                            camera.orthographicSize = startingSize;
                            transform.rotation = startingRotation;
                            skip.enabled = false;
                        }
                    }
                }

                ++i;
            }
        
            //mouse version
            if (Input.GetMouseButtonDown(0))
            {
                if (full)
                    Application.LoadLevel("Game");
                else
                {
                    if (!skipping)
                    {
                        skip.enabled = true;
                        skipping = true;
                    } else
                    {
                        full = true;
                        if (currentScene == 0)
                        {
                            if (GameObject.Find("Black") != null)
                                GameObject.Find("Black").SetActive(false);
                            GameObject.Find("TitleText").renderer.enabled = true;
                        }
                        transform.position = startingPosition;
                        camera.orthographicSize = startingSize;
                        transform.rotation = startingRotation;
                        skip.enabled = false;
                    }
                }
            }
        } else
        {
            if (Time.time > timerStart+timerLength){
                timer = false;
            }
        }
    }
}
