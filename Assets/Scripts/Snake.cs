using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Snake : MonoBehaviour {
    Vector2 dir = Vector2.right; //Direção que a cobra andax
    public AudioSource uepa;
    public AudioSource cutuco;

    private float velPlayer = 0.3f;
    private float velStart;
    bool eat = false; //Comeu?
    // Start is called before the first frame update
    public GameObject tailPrefab; //Tail Prefeb
    List<Transform> tail = new List<Transform>(); //Tail
    GameObject gameController;

    void Start() {

        gameController = GameObject.FindGameObjectWithTag("GameController");
        InvokeRepeating("Move", velPlayer, velPlayer);


    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.RightArrow)) {
            dir = Vector2.right;

        }
        else if ((Input.GetKey(KeyCode.UpArrow))) {
            dir = Vector2.up;

        }
        else if ((Input.GetKey(KeyCode.LeftArrow))) {
            dir = Vector2.left;

        }
        else if ((Input.GetKey(KeyCode.DownArrow))) {
            dir = Vector2.down;

        }
    }
    private void Move() {

        //salvando a coordenada atual
        Vector2 v = transform.position;
        //movimentei a cabeça da cobra
        transform.Translate(dir);
        //tail
        if (eat) {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            eat = false;
        } else if (tail.Count > 0) {
            tail[tail.Count - 1].position = v;
            tail.Insert(0, tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count-1);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll) {

        if (coll.name.StartsWith("Food")) {
            Destroy(coll.gameObject);
            Debug.Log("Comeu");
            gameController.GetComponent<GameController>().IncScore();
            velPlayer += 0.2f;
            eat = true;
            cutuco.Play();
        }
        else {
            Debug.Log("Colidiu com: " + coll.name);
            gameController.GetComponent<GameController>().GameOver();
            uepa.Play();
            //Fim do jogo
        }


    }
}
