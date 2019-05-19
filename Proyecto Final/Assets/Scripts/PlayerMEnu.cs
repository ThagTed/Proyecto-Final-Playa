using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMEnu : MonoBehaviour {

    public int distanceOfRaycast = 40;







    public RaycastHit _hit;
    public GameObject info;
    public bool inf = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out _hit, distanceOfRaycast))
        {
            if (Input.GetButtonDown("Fire1") && _hit.transform.CompareTag("Info"))
            {
                if (!inf) { info.SetActive(true); inf = true; }
                else { info.SetActive(false); inf = false; }
            }
            else if (Input.GetButtonDown("Fire1") && _hit.transform.CompareTag("Salir"))
            {
                Application.Quit();
            }
            else if (Input.GetButtonDown("Fire1") && _hit.transform.CompareTag("Iniciar"))
            {
                SceneManager.LoadScene("Proyecto Final");
            }
        }
    }
}
