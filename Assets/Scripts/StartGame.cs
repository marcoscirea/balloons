using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Application.LoadLevel("Game");
            }
            ++i;
        }
        
        //mouse version
        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("Game");
        }
	}
}
