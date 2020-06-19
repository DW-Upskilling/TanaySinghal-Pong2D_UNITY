using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;

    float height;
    string input;
    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        speed = 5f;

        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0;

        if(Input.GetKey(KeyCode.UpArrow)){
            move = 1 * Time.deltaTime * speed;
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            move = -1 * Time.deltaTime * speed;
        }

        if(transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0){
            move = 0;
        }else if(transform.position.y > GameManager.topRight.y - height / 2 && move > 0){
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }

    public void startGame(){
        enabled = true;
    }

    public void setAlignment(bool align){
        Vector2 pos = Vector2.zero;

        if(align){
            pos = new Vector2(GameManager.topRight.x,0);
            pos -= Vector2.right * transform.localScale.x;
        }else{
            pos = new Vector2(GameManager.bottomLeft.x,0);
            pos += Vector2.right * transform.localScale.x;
        }

        transform.position = pos;
    }
}
