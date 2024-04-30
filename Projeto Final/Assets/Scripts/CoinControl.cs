using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI _scoreText;
    public static int scoreP = 0;

    private Rigidbody2D _rb;
    public int _movespeed = 5;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = scoreP.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveInput = new Vector3(horizontalInput, 0, 0);

        Vector3 nextPosition = transform.position + moveInput * _movespeed * Time.deltaTime;
        _rb.MovePosition(nextPosition);
    }
    void Update()
    {
        _scoreText.text = scoreP.ToString();
    }
}
