using System;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
//using Random = System.Random;
using Random = UnityEngine.Random;

public class SpawnFood : MonoBehaviour {
    
    
    public Transform borderTop;
    public Transform borderLeft;
    public Transform borderRight;
    public Transform borderBottom;
    // Start is called before the first frame update
    public GameObject foodPrefab;
    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
        //Console.WriteLine("Top: {0} \nLeft: {1} \nRight: {2} \nBottom: {3}",borderTop,borderLeft,borderRight,borderBottom);
    }

    // Update is called once per frame
    void Update() {

    }
    void Spawn() {
        //Definir local que a comida será spawnada
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderTop.position.y, borderBottom.position.y);
        Debug.Log("Spawnado em \nX: " + x + " e Y:" + y);
        //Cria a comida
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
