using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherLine : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPostRender()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        Vector3 pos1 = player1.transform.position;
        Vector3 pos2 = player2.transform.position;

        Shader shader = Shader.Find("Hidden/Internal-Colored");
        Material lineMat = new Material(shader);
        GL.Begin(GL.LINES);
        lineMat.SetPass(0);
        GL.Color(new Color(lineMat.color.r, lineMat.color.g, lineMat.color.b, lineMat.color.a));
        GL.Vertex3(pos1.x, pos1.y, pos1.z);
        GL.Vertex3(pos2.x, pos2.y, pos2.z);
        GL.End();
    }

}
