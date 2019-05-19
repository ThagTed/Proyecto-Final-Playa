using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewInfo : MonoBehaviour
{
    public GameObject info;
    public bool inf = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void EnabledInfo()
    {
        if (!inf) { info.SetActive(true); inf = true; }
        else { info.SetActive(false); inf = false; }
    }
}
