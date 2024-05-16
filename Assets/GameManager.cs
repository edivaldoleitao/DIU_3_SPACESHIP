using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool pause = false;
    [SerializeField]public  bool boss = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pause)
            {
                PauseJogo();
            }
            else
            {
                RetomaJogo();
            }
        }
    }

    public void PauseJogo()
    {
        Time.timeScale = 0f;
        pause = true;
        
    }

    public void RetomaJogo()
    {
        Time.timeScale = 1f;
        pause = false;
    }


}
