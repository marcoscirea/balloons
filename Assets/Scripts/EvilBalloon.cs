using UnityEngine;
using System.Collections;

public class EvilBalloon : MonoBehaviour {
    
    Vector3 highedge;
    Vector3 lowedge;
    float speed;
    float amplitude;
    float frequency = 1;
    
    public bool activated = false;
    
    // Use this for initialization
    void Start () {
        lowedge = Camera.main.ViewportToWorldPoint(new Vector3(0,0,Camera.main.nearClipPlane));
        highedge = Camera.main.ViewportToWorldPoint(new Vector3(1f,1f,Camera.main.nearClipPlane));
        float randx = Random.Range((int)lowedge.x+0.3f, (int)highedge.x);
        float randz = Random.Range(-2, 2);
        transform.position = new Vector3(randx, lowedge.y-2f, randz);

        speed = Random.Range(3f, 3.5f);

        //yellow = 3
        GetComponent<Animator>().SetInteger("Color", 3);
    }
    
    // Update is called once per frame
    void Update () {
        if (activated)
        {
            amplitude = Random.Range(0.5f, 2f);
            //Debug.Log(amplitude);
            transform.position += Vector3.up * Time.deltaTime* speed;
            transform.position += amplitude*(Mathf.Sin(2*Mathf.PI*frequency*Time.time) - Mathf.Sin(2*Mathf.PI*frequency*(Time.time - Time.deltaTime)))*transform.right;
            //Debug.Log(highedge.y);
            if (transform.position.y > highedge.y+(gameObject.GetComponent<BoxCollider>().size.y/2))
            {
                //Debug.Log("missedme!");
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pop>().LoseLife();
                Destroy(gameObject);
            }
        }
    }
    
    void OnDestroy() {
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
        audio.Play();
        StartCoroutine(DeathTimer());
    }
    
    IEnumerator DeathTimer(){
        yield return new WaitForSeconds(0.217f);
        Destroy(gameObject);
    }
}
