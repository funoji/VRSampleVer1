using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
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

    [SerializeField] private AudioClip GameoverSE;
    private AudioSource _source;
    void Start()
    {
        _source = GetComponent<AudioSource>();
        GameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver)
        {
            _alpha+=0.6f * Time.unscaledDeltaTime;
            GameOverText.color = new Color(_color._R, _color._G, _color._B, _alpha);
        }
        if (_alpha > 1)
        {
            StartCoroutine("RetryIngame");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _source.PlayOneShot(GameoverSE);
            IsGameOver = true;
            GameOverText.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    private IEnumerator RetryIngame()
    {
        yield return new WaitForSecondsRealtime(5f);
        Time.timeScale = 1f;
        Enemy_SC.ScoreCount = 0;
        SpawnEnemy.Enemy_Count = 50;
        SpawnEnemy.Count = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
