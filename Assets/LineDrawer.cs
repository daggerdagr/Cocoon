using UnityEngine;
using System.Collections;

public class LineDrawer : MonoBehaviour {

	public GameObject cursor;
	private LineRenderer line;
	private int num = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0)) {
			line = GetComponent<LineRenderer> ();
			line.SetVertexCount (num + 1);
			line.SetPosition (num, cursor.transform.position);
			Debug.Log (num);
			num += 1;
		}
	}
}
