using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
        originalPosition = transform.position;
        
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if(transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0){
            direction.y = -direction.y;
        }else if(transform.position.y > GameManager.topRight.y - radius && direction.y > 0){
            direction.y = -direction.y;
        }

        if(transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0){
            transform.position = originalPosition;
            enabled = false;
        }else if(transform.position.x > GameManager.topRight.x - radius && direction.x > 0){
            transform.position = originalPosition;
            enabled = false;
        }
    }

    public void startGame(){
        enabled = true;
    }

    void OnTriggerEnter2D(Collider2D component){
        if(component.tag == "Paddle"){
            direction.x = -direction.x;
        }
    }
}
