using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [SerializeField] GameObject _signCountLifeSM;
    private List<GameObject> _listSignCountLife;
    private int _countLifeSuperMan;
    [SerializeField] float _stepImageLifeSign;
    [SerializeField] float _signLifeX;
    [SerializeField] float _signLifeY;
    [SerializeField] float _signLifeZ;

    void Start()
    {
        _listSignCountLife = new List<GameObject>();
        _countLifeSuperMan = GameObject.FindGameObjectWithTag("SuperMan").GetComponent<SuperMan>().CountLife;
        for (int i = 0; i < _countLifeSuperMan; i++)
        {
            _listSignCountLife.Add(_signCountLifeSM);
        }
        for (int i = 0; i < _listSignCountLife.Count; i++)
        {
            Vector3 location = new Vector3( _signLifeX, _signLifeY , _signLifeZ - (i + 1) * _stepImageLifeSign);
            GameObject imageSign = Instantiate(_listSignCountLife[i]);
            imageSign.transform.position = location;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReducedNumberSignLife()
    {
        GameObject signLife = _listSignCountLife[_listSignCountLife.Count - 1];
        Debug.Log($"_listSignCountLife.Count - 1 = {_listSignCountLife.Count - 1}");
        _listSignCountLife.Remove(signLife); ;
        Destroy(signLife);
    }
}
