using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float _whatAmI;
    [SerializeField]
    private GameObject _theRock;
    [SerializeField]
    private GameObject _theRoot;

    void Start()
    {
        AmIARockorARoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AmIARockorARoot()
    {
        _whatAmI = Random.Range(1, 3);
        if (_whatAmI == 2)
        {
            _theRock.SetActive(true);
            _theRoot.SetActive(false);
        } else
        {
            _theRock.SetActive(false);
            _theRoot.SetActive(true);
        }
    }

  
}
