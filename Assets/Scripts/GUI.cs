using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [SerializeField] GameObject _signCountLifeSM;
    private static List<GameObject> _listSignCountLife;
    private int _countLifeSuperMan;
    [SerializeField] float _stepImageLifeSign;
    [SerializeField] float _signLifeX;
    [SerializeField] float _signLifeY;
    [SerializeField] float _signLifeZ;

    void Start()
    {
        _countLifeSuperMan = GameObject.FindGameObjectWithTag("SuperMan").GetComponent<SuperMan>().CountLife;
        for (int i = 0; i < _countLifeSuperMan; i++)
        {
            Vector3 location = new Vector3( _signLifeX, _signLifeY , _signLifeZ - (i + 1) * _stepImageLifeSign);
            GameObject imageSign = Instantiate(_signCountLifeSM);
            imageSign.transform.position = location;
        }
        _listSignCountLife = new List<GameObject>(GameObject.FindGameObjectsWithTag("SignLife"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ReducedNumberSignLife()
    {
        GameObject signLife = _listSignCountLife[_listSignCountLife.Count - 1];
        _listSignCountLife.Remove(signLife);
        Destroy(signLife.gameObject);
    }
}
