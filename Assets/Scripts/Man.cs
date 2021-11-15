using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    [SerializeField] float _timeLive;
    private GameObject _gameObject;

    private void Start()
    {
        _gameObject = GetComponent<Man>().gameObject;
    }

    private void Update()
    {
        Destroy(_gameObject, _timeLive);
    }
}
