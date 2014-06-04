using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

    Vector3 highedge;
    Vector3 lowedge;
    float speed;

    public bool activated = false;

    public Sprite[] sprites;

	// Use this for initialization
	void Start () {
        lowedge = Camera.main.ViewportToWorldPoint(new Vector3(0,0,Camera.main.nearClipPlane));
        highedge = Camera.main.ViewportToWorldPoint(new Vector3(1f,1f,Camera.main.nearClipPlane));
        float randx = Random.Range((int)lowedge.x+0.3f, (int)highedge.x);
        float randz = Random.Range(-2, 2);
        transform.position = new Vector3(randx, lowedge.y-2f, randz);
        renderer.sortingOrder = (int) -randz;

        speed = Random.Range(1f, 3f);

        GetComponent<SpriteRenderer>().sprite = sprites[(int) Random.Range(0,sprites.Length)];
	}
	
	// Update is called once per frame
	void Update () {
        if (activated)
        {
            transform.position += Vector3.up * Time.deltaTime* speed;
            Debug.Log(highedge.y);
            if (transform.position.y > highedge.y+(gameObject.GetComponent<BoxCollider>().size.y/2))
            {
                //Debug.Log("missedme!");
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pop>().lives--;
                Destroy(gameObject);
            }
        }
	}

    void OnDestroy() {
    }

    public void Fly(){
        activated = true;
    }
}
