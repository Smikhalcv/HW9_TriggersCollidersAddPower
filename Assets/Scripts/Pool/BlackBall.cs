using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBall : MonoBehaviour
{
    [SerializeField] float _power;
    private static List<GameObject> _listWhiteBall;
    private Vector3 _diraction;
    private Vector3 _randomTarget;
    System.Random rnd = new System.Random();
    [SerializeField] float _pause;
    private float _timer;
    private Rigidbody _rigBalckBall;
    private float _minHieghtBall = -10;

    [SerializeField] GameObject _cue;
    private bool _haveCue;
    public bool HaveCue
    {
        get { return _haveCue;  }
    }

    [SerializeField] float _distanceCueY;
    [SerializeField] float _distanceCueZ;



    void Start()
    {
        _listWhiteBall = new List<GameObject>(GameObject.FindGameObjectsWithTag("WhiteBall"));
        _randomTarget = _listWhiteBall[rnd.Next(_listWhiteBall.Count)].transform.position;
        _diraction = _randomTarget - transform.position;
        _timer = _pause;
        _rigBalckBall = gameObject.GetComponent<Rigidbody>();
        GetCue();
    }

    void Update()
    {
        if (_rigBalckBall.velocity.x <= 0.01f && _rigBalckBall.velocity.y <= 0.01f && _rigBalckBall.velocity.z <= 0.01f && _haveCue == false)
        {
            ButtonE.GetCue = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_haveCue == false)
                {
                    GetCue();
                }
            }
            
        }
        if (transform.position.y <= _minHieghtBall)
        {
            Destroy(gameObject);
            Holes.ReturnBlackBall();
        }
    }

    private void Strike()
    {
        if (_listWhiteBall.Count > 0)
        {
            _randomTarget = _listWhiteBall[rnd.Next(_listWhiteBall.Count)].transform.position;
            _diraction = _randomTarget - transform.position;
            gameObject.GetComponent<Rigidbody>().AddForce(_diraction.normalized * _power, ForceMode.Impulse);
            _timer = _pause;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public static void RemoveBallFromList(GameObject ball)
    {
        Debug.Log("Remove ball from list");
        _listWhiteBall.Remove(ball);
    }

    public void GetCue()
    {
        Vector3 positionCue = transform.position;
        positionCue.z = transform.position.z - _distanceCueZ;
        positionCue.y = transform.position.y + _distanceCueY;
        GameObject cue =  GameObject.Instantiate<GameObject>(_cue);
        cue.transform.position = positionCue;
        _haveCue = true;
        ButtonE.GetCue = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cue"))
        {
            Destroy(collision.gameObject);
            _haveCue = false;
            
        }
    }
}
