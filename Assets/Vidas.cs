using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    // Start is called before the first frame update
    public static int vidas = 3;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        score.text = "Vidas: " + vidas;
        vidas = 3;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Vidas: " + vidas;

    }
}
