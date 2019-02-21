using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private const string V = "FireFlys: ";
    public GameObject Player;
    public Text scoreText;
    private string fireFlys;

    // Update is called once per frame
    void Update()
    {
        fireFlys = Player.GetComponent<Player>().FireFlysString;
        var StringCombo = V + fireFlys;
        scoreText.text = StringCombo;
    }
}
