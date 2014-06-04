using UnityEngine;
using System.Collections;

public class Pop : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() {
        int i = 0;
        while (i < Input.touchCount) {
            if (Input.GetTouch(i).phase == TouchPhase.Began) {
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
    }

    void Blow(RaycastHit hit){
        if (hit.collider.gameObject.tag == "Balloon")
        {
            Debug.Log("got me");
            Destroy(hit.collider.gameObject);
        }
    }
}
