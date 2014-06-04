using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

    Vector3 highedge;
    Vector3 lowedge;

    public bool activated = false;

	// Use this for initialization
	void Start () {
        lowedge = Camera.main.ViewportToWorldPoint(new Vector3(0,0,Camera.main.nearClipPlane));
        highedge = Camera.main.ViewportToWorldPoint(new Vector3(1f,1f,Camera.main.nearClipPlane));
        float randx = Random.Range((int)lowedge.x, (int)highedge.x);
        float randz = Random.Range(-2, 2);
        transform.position = new Vector3(randx, lowedge.y-2f, randz);
        renderer.sortingOrder = (int) -randz;
	}
	
	// Update is called once per frame
	void Update () {
        if (activated)
        {
            transform.position += Vector3.up * Time.deltaTime;

            if (!renderer.isVisible && transform.position.y > highedge.y)
            {
                Debug.Log("missedme!");
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
