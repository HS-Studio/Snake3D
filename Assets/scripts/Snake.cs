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

    Vector2 direction = Vector2.up;

    // Start is called before the first frame update
    void Start()
    {   
        //ScoreText.color = new Color(r,g,b,a);
        HiScore = ReadScore();
        HiScoreText.text = HiScore.ToString();
        moveSpeed = 3f;
        Score = 0;
        ScoreText.text = Score.ToString();
        direction = Vector2.up;

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

        for (int i = 1; i < this.initSize; i++)
        {
            _segments_move.Add(Instantiate(this.segmentPrefab_move));
            _segments.Add(Instantiate(this.segmentPrefab));

            _segments_move[i].position = new Vector3(i, 0.0f ,0f);
            _segments[i].position = new Vector3(i, 0.0f ,0f);
            // _segments[i].gameObject.layer = _segments[i].gameObject.layer + 1;
        }

        this.transform.position = Vector3.zero;
        movePoint.position = Vector3.zero;

        RandomPos();
    }

    void Update()
    {   
        //align segments
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        //movement
        Vector2 m_move = MoveAction.ReadValue<Vector2>();
        
        if(Vector3.Distance(transform.position, movePoint.position) <= 0.1f)
        {
            if( m_move.y > m_move.x & m_move.y > -m_move.x & direction != Vector2.down)
            {
                direction = Vector2.up;
            }
            if( m_move.x > m_move.y & m_move.x > -m_move.y & direction != Vector2.left )
            {
                direction = Vector2.right;
            }
            if( -m_move.y > m_move.x & -m_move.y > -m_move.x & direction != Vector2.up )
            {
                direction = Vector2.down;
            }
            if( -m_move.x > m_move.y & -m_move.x > -m_move.y & direction != Vector2.right )
            {
                direction = Vector2.left;
            }

            if (direction == Vector2.left)
            {
                movePoint.position += Vector3.left;
            }
            else if (direction == Vector2.right)
            {
                movePoint.position += Vector3.right;
            }
            if (direction == Vector2.down)
            {
                movePoint.position += Vector3.down;
            }
            else if (direction == Vector2.up)
            {
                movePoint.position += Vector3.up;
            }
            for (int i = _segments_move.Count - 1; i > 0; i--)
            {
                _segments_move[i].position = new Vector3(Mathf.Round(_segments_move[i - 1].position.x), Mathf.Round(_segments_move[i - 1].position.y), 0.0f);
                _segments_move[0].rotation = transform.rotation;
                _segments_move[i].rotation = _segments_move[i - 1].rotation;
            }
        }

        //collision with body
        for( int i = 0; i <= _segments_move.Count -1; i++ )
        {
            if(Vector3.Distance(movePoint.position, _segments_move[i].position) == 0.0f)
            {
                ResetGame();
            }

            if(Vector3.Distance(Food.position, _segments_move[i].position) == 0.0f)
            {
                RandomPos();
            }
        }

        //rotate to movedirection
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
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

    private void FixedUpdate()
    {   
        // Look To Fruite

        //EyeL.forward = Food.position - EyeL.position;
        //EyeR.forward = Food.position - EyeR.position;

        EyeL.right = Food.position - EyeL.position;
        EyeR.right = Food.position - EyeR.position;

        float EyeLZ = EyeL.eulerAngles.z;
        float EyeRZ = EyeR.eulerAngles.z;

        EyeL.eulerAngles = new Vector3(0,0, EyeLZ);
        EyeR.eulerAngles = new Vector3(0,0, EyeRZ);


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

        float x = Random.Range(bounds.min.x, bounds.max.x );
        float y =  Random.Range(bounds.min.y, bounds.max.y );

        Food.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
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
