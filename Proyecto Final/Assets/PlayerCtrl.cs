using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 30f;
    public float gravity = 15f;
    private CharacterController controller;
    public GameObject wall;

    public int distanceOfRaycast = 20;
    public RaycastHit _hit;

    public int count;
    public Text countText;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        wall.SetActive(false);
        countText.text = "Basura recolectada: " + count.ToString();
        winText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out _hit, distanceOfRaycast))
        {
            if (Input.GetButtonDown("Fire1") && _hit.transform.CompareTag("Credit"))
            {
                SceneManager.LoadScene("Creditos");
            }
            else if (Input.GetButtonDown("Fire1")&& _hit.transform.CompareTag("Coin"))
            {
                _hit.transform.gameObject.GetComponent<Collect>().Picking();
                count++;
                countText.text = "Basura recolectada: " + count.ToString();
            }
        }
        PlayerMovement();
        if (count == 17)
        {
            wall.SetActive(true);
            winText.enabled = true;
            transform.position = new Vector3(0f, 24f, 0f);
            transform.rotation = new Quaternion(0f, 90f, 0f, 0f);
            
        }
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Vertical");
        float vertical = Input.GetAxis("Horizontal");

        Vector3 diretion = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = diretion * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);
    }
}
