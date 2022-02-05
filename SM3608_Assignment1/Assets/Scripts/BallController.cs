using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;

    private bool isControl;
    private bool scored;
    [Range(5, 15)]
    public int speed;

    public float fieldSize;
    private float Size;

    [SerializeField] private Material[] materials;
    private MeshRenderer mR;
    private DestroyInstance destroy;
    public BallColor Bcolor;


    // Start is called before the first frame update
    void Awake()
    {
        GameManager.OnGameStateChange += OnGameStateChanged;
        
        rb = this.GetComponent<Rigidbody>();
        mR = this.GetComponent<MeshRenderer>();
        destroy = this.GetComponent<DestroyInstance>();
        Size = transform.position.x + fieldSize;

        int enumLength = System.Enum.GetValues(typeof(BallColor)).Length;
        var ColorSelect = UnityEngine.Random.Range(0, enumLength);
        object select = System.Enum.ToObject(typeof(BallColor), ColorSelect);
        SelectColor(select);
        destroy.enabled = false;
        //scored = false; 

    }

    private void OnGameStateChanged(GameState state)
    {
        isControl = state == GameState.PlayerMoving;
        if (state == GameState.BallScoring) HandleScore(scored);

    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= OnGameStateChanged;
    }



    // Update is called once per frame
    void Update()
    {
        if (isControl) 
        {
            InputReader();
            rb.isKinematic = true;
        }
        else rb.isKinematic = false;
    }


    private void InputReader() 
    {

        //range restriction according to field

        Vector3 pos = transform.position;
        if (pos.x >= -Size && pos.x <= + Size) // will stuck if over
        {
            pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            transform.position = new Vector3(pos.x, transform.position.y, transform.position.z);
        }

        if (pos.x >= Size) transform.position = new Vector3(Size, transform.position.y, transform.position.z); 
        if (pos.x <= -Size) transform.position = new Vector3(-Size, transform.position.y, transform.position.z);


        if (Input.GetKeyDown(KeyCode.Space)) GameManager.Instance.UpdateGameState(GameState.BallRolling);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score")) 
        {
            scored =  other.gameObject.GetComponent<MeshRenderer>().material.ToString() == mR.material.ToString();
            Debug.Log(scored + " " + other.gameObject.GetComponent<MeshRenderer>().material + " " + mR.material);
            GameManager.Instance.UpdateGameState(GameState.BallScoring);
            destroy.enabled = true;
            Destroy(this);
        }
    }

    void HandleScore(bool scored) 
    {
        if(scored) ScoreManager.score++;
        GameManager.Instance.UpdateGameState(GameState.DisplayScore);
    }

    void SelectColor(object select) 
    {

        switch (select)
        {
            case BallColor.Red:
                mR.material = materials[0];
                break;
            case BallColor.Green:
                mR.material = materials[1];
                break;

            case BallColor.Blue:
                mR.material = materials[2];
                break;

            case BallColor.Cyan:
                mR.material = materials[3];
                break;
            case BallColor.Magenta:
                mR.material = materials[4];
                break;

            case BallColor.Yellow:
                mR.material = materials[5];
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(select), select, null);

        }


    }
}

public enum BallColor 
{
    Red, Green, Blue, Cyan, Magenta, Yellow
}
