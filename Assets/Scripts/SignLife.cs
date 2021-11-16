using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignLife : MonoBehaviour
{
    public void DestroySignLife()
    {
        DestroyImmediate(gameObject);
    }
}
