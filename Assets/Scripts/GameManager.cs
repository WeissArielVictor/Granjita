using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _score;
    public int score
    {
        get { return _score;}
        private set
        {
            if (value.GetType() == typeof(int))
            {
                _score = value;
            }
            else
            {
                throw new System.ArgumentException("score debe ser int");
            }
        }
    }
    void ChangeScore(int a)
    {
        score += 5;
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
