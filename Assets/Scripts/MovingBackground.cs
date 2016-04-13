using UnityEngine;
using System.Collections;

public class MovingBackground : MonoBehaviour {

	private float pos = 0f;
	public Vector2 speed = Vector2.zero;
	public GameObject bgObject;
	public float delay = 2.0f;
	public Vector3 origPos;
	public bool active = true;

	void Awake(){
		origPos = bgObject.transform.position;
	}
	void Start(){
	}


	void Update(){
		pos += speed.x;
		transform.position = new Vector2(transform.position.x + speed.x, transform.position.y);
		if (transform.position.x < 150){
			if(active){
				GameObject clone = (GameObject)Instantiate(bgObject, new Vector3(1000, 128, -974), transform.rotation);
				clone.AddComponent<RectTransform>();
				clone.transform.parent = Camera.main.transform;
				clone.GetComponent<MovingBackground>().enabled = true;
				clone.SetActive(true);
				active = false;
			}
		}
		if(transform.position.x < - 2000){
			Destroy(bgObject);
		}
	}

}
