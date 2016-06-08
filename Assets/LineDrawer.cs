using UnityEngine;
using System.Collections;

public class LineDrawer : MonoBehaviour {

	public GameObject cursor;
	private LineRenderer line;
	private int num = 0;
	private bool lineOn;
	public GameObject lineOrig;
	private GameObject currLine;
	private int mode = 0;

	// Use this for initialization
	void Start () {
	}

	void ModeChange() {
		mode = (mode + 1) % 3;
	}
	
	// Update is called once per frame
	void Update () {
		//downclick = false;
		//Object.Instantiate (this);
		//Debug.Log(Input.GetKey(KeyCode.A));
		if (mode == 0) {
			if (lineOn == false & Input.GetKey (KeyCode.Mouse0)) {
				lineOn = true;
				num = 0;
				Debug.Log ("hit");
				currLine = Object.Instantiate (lineOrig);
				currLine.transform.parent = lineOrig.transform.parent; 
			} else if (lineOn == true & !Input.GetKey (KeyCode.Mouse0)) {
				lineOn = false;
				Debug.Log ("done");
			}

			//Debug.Log (lineOn);
			if (Input.GetKey (KeyCode.Mouse0)) {
				line = currLine.GetComponent<LineRenderer> ();
				line.SetVertexCount (num + 1);
				line.SetPosition (num, cursor.transform.position);
				//Debug.Log (num);
				num += 1; 
			}	
		}
	}
}
