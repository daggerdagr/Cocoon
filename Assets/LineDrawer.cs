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
		//line = GetComponent<LineRenderer> ();
		Debug.Log (num);
		num += 1;
	}
}
