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


        speed = Random.Range(1f, 3f);

        int rand = (int) Random.Range(0, sprites.Length);
        //Debug.Log(sprites[rand]);
        transform.FindChild("Sprite").GetComponent<SpriteRenderer>().sprite = sprites[rand];
        transform.FindChild("Sprite").renderer.sortingOrder = (int) -randz;

        //set color of exploding animation: blue 0-2, green 3, red 7-8, purple 5-6, yellow 4,9
        switch (rand)
        {
            case 0:
            case 1:
            case 2:
                //blue color = 1
                GetComponent<Animator>().SetInteger("Color", 1);
                break;
            case 3:
                //green color = 0
                GetComponent<Animator>().SetInteger("Color", 0);
                break;
            case 9:
                //yellow = 3
                GetComponent<Animator>().SetInteger("Color", 3);
                break;
            case 4:
            case 7:
            case 8:
                //red = 2
                GetComponent<Animator>().SetInteger("Color", 2);
                break;
            case 5:
            case 6:
                //purple = 4
                GetComponent<Animator>().SetInteger("Color", 4);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (activated)
        {
            transform.position += Vector3.up * Time.deltaTime* speed;
            //Debug.Log(highedge.y);
            if (transform.position.y > highedge.y+(gameObject.GetComponent<BoxCollider>().size.y/3))
            {
                //Debug.Log("missedme!");
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pop>().LoseLife();
                Destroy(gameObject);
            }
        }
	}

    public void Fly(){
        activated = true;
    }

    public void Die(){
        //Debug.Log("going to die");
        activated = false;
        collider.enabled = false;
        //animation.Play("Explosion");
        GetComponent<Animator>().SetTrigger("Dying");
        //GetComponent<Animator>().animation.Play();
        audio.Play();
        StartCoroutine(DeathTimer());
    }

    IEnumerator DeathTimer(){
            yield return new WaitForSeconds(0.217f);
            Destroy(gameObject);
        }
}
