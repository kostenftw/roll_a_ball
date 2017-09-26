using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller : MonoBehaviour
{
    public float speed;
    public Text count_text;
    public Text win_text;
    const int win_score = 12;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        count = 0;
        win_text.text = "";
        set_count_text();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float move_horizontal = Input.GetAxis("Horizontal");
        float move_vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(move_horizontal, 0, move_vertical); 

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pick_up"))
        {
            other.gameObject.SetActive(false);
            count++;
            set_count_text();
        }
    }

    void set_count_text()
    {
        count_text.text = "Count: " + count.ToString();
        if (count >= win_score)
        {
            win_text.text = "You Win!";
        }
    }
}
