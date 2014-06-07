using UnityEngine;
using System.Collections;

public class Message : MonoBehaviour {

    Vector3 finalScale;
    public float speed = 0.025f;
    public int timerlength = 3;
    float timerstart;
    TextMesh t;
    string[] messages = {"Fabulous", "Marvelous", "Ballooney", "OMG", "Poptastic", "Amazing",
        "Awesome",
        "Blithesome",
        "Excellent",
        "Fabulous",
        "Fantastic",
        "Favorable",
        "Fortuitous",
        "Great",
        "Incredible",
        "Ineffable",
        "Mirthful",
        "Outstanding",
        "Perfect",
        "Propitious",
        "Remarkable",
        "Smart",
        "Spectacular",
        "Splendid",
        "Stellar",
        "Stupendous",
        "Super",
        "Ultimate",
        "Unbelievable",
        "Wondrous"};

    public Color[] colors;

	// Use this for initialization
    void Start () {
        finalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        timerstart = Time.time;
        t = gameObject.GetComponent<TextMesh>();

        t.text = messages[(int)Random.Range(0, messages.Length)];
        t.color = colors [Random.Range(0, colors.Length - 1)];
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x < finalScale.x)
            transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime* speed;

        if (Time.time > timerstart + timerlength)
        {
            if(t.color.a>0){
                Color tmp = t.color;
                tmp.a -= Time.deltaTime;
                t.color = tmp;
            }
            else{
            Destroy(gameObject);
            }
        }
	}
}
