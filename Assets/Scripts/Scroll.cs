using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    //private float scrollSpeed = 8f;
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * GameManager.Instance.GetScrollSpeed() * Time.deltaTime);
        //transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
    }
}
