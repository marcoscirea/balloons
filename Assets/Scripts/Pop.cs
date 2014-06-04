﻿using UnityEngine;
using System.Collections;

public class Pop : MonoBehaviour {

    public int lives;
    public int points;
    int messagePoints;

    public GameObject message;

	// Use this for initialization
	void Start () {
        lives = 5;
        points = 0;
        messagePoints = 0;
        //Camera.main.aspect = (Screen.currentResolution.width / Screen.currentResolution.height); //so this would stretch the game scene in order to adjust it to the Device's screen
	}
	
	// Update is called once per frame
	void Update() {
        if (lives > 0)
        {
            int i = 0;
            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                        Blow(hit);
                }
                ++i;
            }

            //mouse version
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                    Blow(hit);
            }
        } else
        {
            Debug.Log("You lose");
        }

        if (points > messagePoints && points % 10 == 0)
        {
            Instantiate(message);
            messagePoints=points;
        }
    }

    void Blow(RaycastHit hit){
        if (hit.collider.gameObject.tag == "Balloon")
        {
            //Debug.Log("got me");
            points +=1;
            Destroy(hit.collider.gameObject);
        }
    }
}