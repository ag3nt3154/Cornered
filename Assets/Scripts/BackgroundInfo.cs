using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundInfo : MonoBehaviour
{
    public float offset_coeff = 0.4f;
    public float tether_length = 40.0f;
    public float energy = 100.0f;
    public GameObject player1;
    public GameObject player2;
    public GameObject shield;
    public Text myText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myText.text = "Energy: " + energy.ToString();

        if (Input.GetKey("."))
        {
            shield.SetActive(true);
            shield.transform.position = player1.transform.position;
            energy -= 1;
        }
        else if (Input.GetKey("z"))
        {
            shield.SetActive(true);
            shield.transform.position = player2.transform.position;
            energy -= 1;
        }
        else { shield.SetActive(false); }


        




    }
}
