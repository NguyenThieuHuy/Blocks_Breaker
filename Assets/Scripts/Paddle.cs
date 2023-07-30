using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenwidthinunits = 21f;
    [SerializeField] float maxpaddlepos = 20f;
    [SerializeField] float minpaddlepos = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.mousePosition.x / Screen.width * screenwidthinunits);
        float mousePos = Input.mousePosition.x / Screen.width * screenwidthinunits;
        float paddlePosX = Mathf.Clamp(mousePos, minpaddlepos, maxpaddlepos);
        Vector2 paddlePos = new Vector2(paddlePosX, transform.position.y);
        transform.position = paddlePos;
    }
}
