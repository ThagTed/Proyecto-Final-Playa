using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour {

    public GameObject text;
    public GameObject _text;
    public float speed = 1;

	// Update is called once per frame
	void Update ()
    {
        if (_text.transform.position.y < 150f)
        {
            Vector3 mov = new Vector3(0, speed / 10000, 0);
            text.transform.Translate(mov);
            _text.transform.Translate(mov);
        }
        StartCoroutine(waitFor());
    }

    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(33);
        SceneManager.LoadScene("Menu");
    }
}
