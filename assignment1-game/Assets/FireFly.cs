using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFly : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CheckCloseTo;
    public int Range = 2;
    public GameObject Player;
    //Player playerscript = Player.GetComponent<Player>();
    void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<Player>().Fireflys += 1;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, CheckCloseTo.transform.position) < Range)
        {
            //Player.GetComponent<Player>().Fireflys += 1;
            Destroy(gameObject);
        }
    }
}
