using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class tutorialManager : MonoBehaviour
{
    [SerializeField] ActiveStateSelector State;
    [SerializeField] TextMeshProUGUI pinchText;
    [SerializeField] GameObject ShootText;
    [SerializeField] GameObject BulletBox;
    [SerializeField] GameObject mato;
    [SerializeField] GameObject endthis;
    [SerializeField] GameObject spwanbox;
    [SerializeField] GameObject spwanbox2;
    [SerializeField] GameObject[] matos;
    bool pinched = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            SceneManager.LoadScene("sizukistagedesign");
        }
    }

    private void Start()
    {
        for(int i = 0; i < matos.Length; i++)
        {
            matos[i].SetActive(false);
        }
        spwanbox.SetActive(false);
        spwanbox2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!BulletBox)
        {
            pinchText.enabled = false;
            ShootText.SetActive(true);
            spwanbox.SetActive(true);
            spwanbox2.SetActive(true);

        }
        if(!mato)
        {
            ShootText.SetActive(false);
            endthis.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = true;
            for (int i = 0; i < matos.Length; i++)
            {
                matos[i].SetActive(true);
            }
        }
    }
}
