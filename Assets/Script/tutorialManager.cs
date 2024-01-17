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
    bool pinched = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            SceneManager.LoadScene("sizukistagedesign");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!BulletBox)
        {
            pinchText.enabled = false;
            ShootText.SetActive(true);
        }
        if(!mato)
        {
            ShootText.SetActive(false);
            endthis.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
