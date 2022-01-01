using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    private List<Transform> _segments = new List<Transform>();
    private List<Transform> _segments_move = new List<Transform>();

    [SerializeField]
    private Transform segmentPrefab, segmentPrefab_move, movePoint, Food, EyeL, EyeR;

    public int initSize = 4, HiScore;
    public static int Score;
    private float moveSpeed, rotateSpeed = 480;

    public BoxCollider gridArea;

    private SnakeMove snakeMove;
    private InputAction MoveAction;

    public Text HiScoreText;
    public Text ScoreText;

    public AudioSource eat;

    Vector3 direction, MoveDirection;

    // Start is called before the first frame update
    void Start()
    {   
        //ScoreText.color = new Color(r,g,b,a);
        HiScore = ReadScore();
        HiScoreText.text = HiScore.ToString();
        moveSpeed = 3f;
        Score = 0;
        ScoreText.text = Score.ToString();
        direction = Vector3.forward;
        MoveDirection = direction;

        snakeMove = new SnakeMove();
        MoveAction = snakeMove.control.m_MoveAction;
        MoveAction.Enable();

        for (int i = 1; i < _segments_move.Count; i++)
        {
            Destroy(_segments_move[i].gameObject);
        }

        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments_move.Clear();
        _segments_move.Add(this.transform);
        
        _segments.Clear();
        _segments.Add(this.transform);

        // Create Snake
        for (int i = 1; i < this.initSize; i++)
        {
            _segments_move.Add(Instantiate(this.segmentPrefab_move));
            _segments.Add(Instantiate(this.segmentPrefab));

            _segments_move[i].position = new Vector3(i, 0.0f ,0.0f);
            _segments[i].position = new Vector3(i, 0.0f ,0.0f);
            // _segments[i].gameObject.layer = _segments[i].gameObject.layer + 1;
        }

        this.transform.position = Vector3.zero;
        movePoint.position = Vector3.zero;

        RandomPos();
    }

    private void FixedUpdate()
    {
        // Look To Fruite

        // now handled with Look At Constraint
        //EyeL.right = Food.position - EyeL.position;
        //EyeR.right = Food.position - EyeR.position;


    }

    void Update()
    {   
        //align segments
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        //movement
        Vector2 m_move = MoveAction.ReadValue<Vector2>();

        Debug.Log(m_move);

        if ( m_move.y > m_move.x & m_move.y > -m_move.x)
        {
            direction = Vector3.forward;
        }
        if( m_move.x > m_move.y & m_move.x > -m_move.y)
        {
            direction = Vector3.right;
        }
        if( -m_move.y > m_move.x & -m_move.y > -m_move.x)
        {
            direction = Vector3.back;
        }
        if( -m_move.x > m_move.y & -m_move.x > -m_move.y )
        {
            direction = Vector3.left;
        }


        if(Vector3.Distance(transform.position, movePoint.position) <= 0.1f)
        {

            // change move direction of the move point
            if (MoveDirection == Vector3.left & direction != Vector3.right)
            {
                MoveDirection = direction;
            }
            if (MoveDirection == Vector3.right & direction != Vector3.left)
            {
                MoveDirection = direction;
            }
            if (MoveDirection == Vector3.forward & direction != Vector3.back)
            {
                MoveDirection = direction;
            }
            if (MoveDirection == Vector3.back & direction != Vector3.forward)
            {
                MoveDirection = direction;
            }

            // move the move point
            movePoint.position += MoveDirection;

            //place and rotate dummy segments to the segment in front
            for (int i = _segments_move.Count - 1; i > 0; i--)
            {
                _segments_move[i].position = new Vector3(Mathf.Round(_segments_move[i - 1].position.x), 0.0f, Mathf.Round(_segments_move[i - 1].position.z));
                _segments_move[0].rotation = transform.rotation;
                _segments_move[i].rotation = _segments_move[i - 1].rotation;
            }
        }

        //collision with body
        for (int i = 0; i <= _segments_move.Count - 1; i++)
        {
            if (Vector3.Distance(movePoint.position, _segments_move[i].position) == 0.0f)
            {
                ResetGame();
            }

            if (Vector3.Distance(Food.position, _segments_move[i].position) == 0.0f)
            {
                RandomPos();
            }
        }

        //rotate to movedirection
        Quaternion toRotation = Quaternion.LookRotation(Vector3.up, MoveDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = Vector3.MoveTowards(_segments[i].position, _segments_move[i].position, moveSpeed * Time.deltaTime);
            _segments[i].rotation = Quaternion.RotateTowards(_segments[i].rotation, _segments_move[i].rotation, rotateSpeed * Time.deltaTime);
        }

        //collision with Fruite
        if (Vector3.Distance(movePoint.position, Food.position) == 0.0f)
        {
            Grow();
            RandomPos();
        }

        //collision with wall || out of bounds
        Bounds bounds = gridArea.bounds;
        if (!bounds.Contains(movePoint.position))
        {
            ResetGame();
        }
    }



    public static void WriteScore(int HiScore_)
    {
        string path = Application.persistentDataPath + "/Score.txt";
        File.WriteAllText(path, HiScore_.ToString());
    }

    public int ReadScore()
    {
        string path = Application.persistentDataPath + "/Score.txt";
        string s_score = "";
        int HiScore_ ;
        //Read the text directly from the Score.txt file
        if(File.Exists(path))
        {
            s_score = File.ReadAllText(path);
            HiScore_ = int.Parse(s_score);
        }
        else
        {
            HiScore_ = 0;
        }

        return HiScore_;
        //Debug.Log(s_score);
        
    }

    //friut position
    private void RandomPos()
    {
        Bounds bounds = gridArea.bounds;

        float x = Random.Range( bounds.min.x, bounds.max.x );
        float z =  Random.Range (bounds.min.z, bounds.max.z );

        Food.position = new Vector3( Mathf.Round(x), 0.0f, Mathf.Round(z) );
    }

    private void Grow()
    {   
        Score += 1;
        ScoreText.text = Score.ToString();

        if( Score > HiScore)
        {
            HiScoreText.text = Score.ToString();
        }
        
        Transform segment_move = Instantiate(this.segmentPrefab_move);
        segment_move.position = _segments_move[_segments_move.Count -1].position;
        _segments_move.Add(segment_move);

        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count -1].position;
        _segments.Add(segment);
        // _segments[_segments.Count - 1].gameObject.layer = _segments[_segments.Count - 2].gameObject.layer + 1;

        if (moveSpeed <= 8)
        {
            moveSpeed += 0.1f;
        }

        eat.Play();

        //Debug.Log(moveSpeed);
    }

    private void ResetGame()
    {   

        //Start();
        if(Score > HiScore)
        {
            HiScore = Score;
            WriteScore(HiScore);
        }
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {

    }
    */

}
