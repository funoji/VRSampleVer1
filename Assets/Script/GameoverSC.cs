using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameoverSC : MonoBehaviour
{
    [System.Serializable]
    public class textColor
    {
        public float _R;
        public float _G;
        public float _B;
    }
    [SerializeField] private TextMeshProUGUI GameOverText;
    [SerializeField] public textColor _color;

    private float _alpha = 0;
    private bool IsGameOver = false;
    void Start()
    {
        GameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver)
        {
            _alpha+=0.01f * Time.unscaledDeltaTime;
            GameOverText.color = new Color(_color._R, _color._G, _color._B, _alpha);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            IsGameOver = true;
            GameOverText.enabled = true;
            Time.timeScale = 0f;
        }
    }
}
