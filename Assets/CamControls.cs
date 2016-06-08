using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CamControls : MonoBehaviour {

	public GameObject cursor;
	private Vector3 cursorcoord;
	public float dist;
	//private int[] modes = new int[0, 1, 2];
	private int mode = 0;
	public Text modeStatus;
	public GameObject lineControl;
	private Transform transf;

	// Use this for initialization
	void Start () {
		//OVRTouchpad.Create ();
		OVRTouchpad.TouchHandler += HandleTouchHandler;
		transf = transform.parent; 
	}

	void HandleTouchHandler (object sender, System.EventArgs e) {
		OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
		if (mode == 1) {
			if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Right) {
				dist += (float) 0.5;
			} else if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Left) {
				if (dist > 0) {
					dist -= (float) 0.5;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			mode = (mode + 1) % 3;
			lineControl.SendMessage ("ModeChange");
		}

		cursor.SetActive (true);
		if (mode == 0) {
			modeStatus.text = "Draw Mode";
		} else if (mode == 1) {
			modeStatus.text = "Tool Mode";
		} else {
			modeStatus.text = "Move Mode";
			cursor.SetActive (false);
		}

		if (mode == 2 & Input.GetKey (KeyCode.Mouse0)) {
			transf.transform.position += transform.forward * Time.deltaTime * 5;
		}
			

		cursorcoord = this.transform.forward;
		cursorcoord = Vector3.Scale (cursorcoord, new Vector3 (dist, dist, dist));
		cursor.transform.position = this.transform.position + cursorcoord;

		//if (Input.GetAxis ("Mouse Y") > 0) {
		//	dist += (float) 0.5;
		//} else if (Input.GetAxis ("Mouse Y") < 0) {
		//	if (dist > 0) {
		//		dist -= (float) 0.5;
		//	}
		//}

		//dist += Input.GetAxis ("Mouse Y") * ((float) 0.1);
		//Debug.Log ((float)0.1);

		Debug.Log (transform.forward);
		//Debug.Log (Input.GetAxis("Mouse X"));

		//cam controoools
		//w/ mouse:
		//float moveLR = Input.GetAxis("Mouse X");
		//float moveUD = Input.GetAxis("Mouse Y");
		float moveLR = Input.GetAxis("Horizontal");
		float moveUD = Input.GetAxis("Vertical");
		this.transform.Rotate (new Vector3 (-1 * moveUD, 0, 0));
		this.transform.Rotate (new Vector3 (0, moveLR, 0), Space.World);
		//Debug.Log (moveUD);
		//Debug.Log (moveLR);
	}
}
