using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Fireflys = 0;
    public string FireFlysString = null;
    // Start is called before the first frame update
    void Start()
    {
        Fireflys = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("AHHH: " + Fireflys.ToString());
        FireFlysString = Fireflys.ToString();
    }
}
