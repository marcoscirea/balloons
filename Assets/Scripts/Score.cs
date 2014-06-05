using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public static float score;

	// Use this for initialization
	void Start () {
	    if (Application.loadedLevelName == "Game")
        {
            score = 0;
        } else
        {
            if (GetComponent<TextMesh>()!=null){
                GetComponent<TextMesh>().text = score.ToString();
            }
        }
	}

    public static void Set(float s){
        score = s;
    }
}
