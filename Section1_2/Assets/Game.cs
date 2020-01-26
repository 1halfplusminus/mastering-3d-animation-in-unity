using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game : MonoBehaviour
{

    public MyPlayer player;
    public MyGameState state;

    public UnityEngine.Canvas gameOver;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!player.controller.Grounded)
        {
            Debug.Log("here");
            state.gameover = true;
            player.controller.gameObject.GetComponent<Rigidbody>().useGravity = false;
            player.controller.enabled = false;
            gameOver.gameObject.SetActive(true);
        }
    }
}
