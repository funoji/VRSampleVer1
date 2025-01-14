using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Oculus.Interaction
{
    public class bulletUI : MonoBehaviour
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] Transform[] point = new Transform[3];
        GameObject[] bulletForUi = new GameObject[3];
        [SerializeField]ActiveStateSelector activeStateSelector;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                bulletForUi[i] = Instantiate(bulletPrefab, point[i].position, Quaternion.identity);
                bulletForUi[i].transform.parent = transform;
                bulletForUi[i].transform.localScale = Vector3.one * 0.1f;
                bulletForUi[i].SetActive(false);
            }
        }
        private void Update()
        {
            int bulletCount = activeStateSelector.getbullet();

            // すべての bulletForUi を非表示にする
            for (int i = 0; i < 3; i++)
            {
                bulletForUi[i].SetActive(false);
            }

            // bulletCount の数だけ bulletForUi を表示する
            for (int i = 0; i < bulletCount; i++)
            {
                bulletForUi[i].SetActive(true);
            }
        }
    }
}
