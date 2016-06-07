using UnityEngine;
using System.Collections;

public class CamControls : MonoBehaviour {

	public GameObject cursor;
	private Vector3 cursorcoord;
	public float dist;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		cursorcoord = this.transform.forward;
		cursorcoord = Vector3.Scale (cursorcoord, new Vector3 (dist, dist, dist));
		cursor.transform.position = cursorcoord;

		//Debug.Log (transform.forward);
		//Debug.Log (Input.GetAxis("Mouse X"));

		//cam controoools
		//w/ mouse:
		//float moveLR = Input.GetAxis("Mouse X");
		//float moveUD = Input.GetAxis("Mouse Y");
		float moveLR = Input.GetAxis("Horizontal");
		float moveUD = Input.GetAxis("Vertical");
		this.transform.Rotate (new Vector3 (-1 * moveUD, moveLR, 0), Space.World);
		Debug.Log (moveUD);
		Debug.Log (moveLR);
	}
}
