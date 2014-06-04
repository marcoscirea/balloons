using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {
    
    Pop pop;
    // Use this for initialization
    void Start () {
        pop = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pop>();
        guiText.text = "Points: " + pop.points;
    }
    
    // Update is called once per frame
    void Update () {
        guiText.text = "Points: " + pop.points;
    }
}
