using UnityEngine;
using System.Collections;

public class CameraWobble : MonoBehaviour {

    Vector3 direction;
    Vector3 startingPosition;
    bool timer = true;
    float timerStart;
    float timerLength= 3f;

	// Use this for initialization
	void Start () {
        direction = Vector3.zero;
        startingPosition = transform.position;
        timerStart = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (direction == Vector3.zero || Vector3.Distance(transform.position, startingPosition) > 0.1f){
            direction = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f),0);
        }
        transform.position += direction * Time.deltaTime*0.1f;

        if (!timer)
        {
            int i = 0;
            while (i < Input.touchCount)
            {
                Application.LoadLevel("Game");
            
                ++i;
            }
        
            //mouse version
            if (Input.GetMouseButtonDown(0))
            {
                Application.LoadLevel("Game");
            }
        } else
        {
            if (Time.time > timerStart+timerLength){
                timer = false;
                GameObject.Find("Skip").guiText.enabled = true;
            }
        }
	}
}
