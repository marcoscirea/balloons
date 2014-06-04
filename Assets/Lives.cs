using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

    Pop pop;
	// Use this for initialization
	void Start () {
        pop = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pop>();
        guiText.text = "Lives: " + pop.lives;
	}
	
	// Update is called once per frame
	void Update () {
        guiText.text = "Lives: " + pop.lives;
	}
}
