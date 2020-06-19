using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public static Vector2 topRight, bottomLeft;
    // Start is called before the first frame update
    private Ball b;
    private Paddle p1,p2;
    void Start()
    {
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));

        b = Instantiate(ball) as Ball;
        p1 = Instantiate(paddle) as Paddle;
        p2 = Instantiate(paddle) as Paddle;

        p1.setAlignment(false);
        p2.setAlignment(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            b.startGame();
            p1.startGame();
            p2.startGame();
        }
    }
}
