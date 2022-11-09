using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private int tempo = 20; //tempo comida
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,tempo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
