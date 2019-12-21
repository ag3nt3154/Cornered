using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tether2Controller : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject background;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float offset_coeff = background.GetComponent<BackgroundInfo>().offset_coeff;
        Vector3 poffset = Player2.transform.position - Player1.transform.position;
        Vector3 offset = (poffset / (poffset.sqrMagnitude)) * offset_coeff;
        transform.position = offset + Player2.transform.position;
        
        transform.eulerAngles = new Vector3(0.0f, 0.0f, Mathf.Atan2(-poffset.x, poffset.y) * Mathf.Rad2Deg + 90.0f);



    }
}
