using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Oculus.Interaction
{
    public class BulletManager : MonoBehaviour
    {
        int BulletCountL = 0;
        int BulletCountR = 0;

        readonly int BulletMaxCount = 1;
        readonly int BulletMinCount = 0;

        public string enemyTag = "Enemy";

        private List<GameObject> objectsToWatch = new List<GameObject>();

        [SerializeField] RayInteractor[] _rayInteractor;

        [SerializeField] GameObject[] GunActions;//0 Left / 1 Right
        [SerializeField] GameObject[] RayInstractorObjs;//0 Left / 1 Right

        public static bool IsFillList = false;
        void Start()
        {
            // シーン内の全ての敵を取得してリストに追加
            GameObject[] allEnemy = FindObjectsOfType<GameObject>();
            foreach (GameObject obj in allEnemy)
            {
                if (obj.CompareTag(enemyTag))
                {
                    objectsToWatch.Add(obj);
                }
            }
        
            this.AssertField(_rayInteractor, nameof(_rayInteractor));
            
        }

        void Update()
        {
            //if (SpawnEnemy.IsSpawn)
            //{
            //    GameObject[] allEnemy = FindObjectsOfType<GameObject>();
            //    foreach (GameObject obj in allEnemy)
            //    {
            //        if (obj.CompareTag(enemyTag))
            //        {
            //            objectsToWatch.Add(obj);
            //        }
            //    }
            //    IsFillList = true;
            //}
            // 監視対象の敵が存在し、破壊されたかどうかを確認
            for (int i = objectsToWatch.Count - 1; i >= 0; i--)
            {
                if (objectsToWatch[i] == null)
                {
                    if (!_rayInteractor[0].ModeLR)
                    {
                        Mathf.Clamp(BulletCountL, BulletMinCount, BulletMaxCount);
                        BulletCountL++;
                    }

                    if(_rayInteractor[1].ModeLR)
                    {
                        Debug.Log("rayinteractorR_Is_Fill");
                        Mathf.Clamp(BulletCountR, BulletMinCount, BulletMaxCount);
                        BulletCountR++;
                    }

                    objectsToWatch.RemoveAt(i);
                }
            }

            if(BulletCountL == BulletMaxCount)
            {
                if(!GunActions[0].activeSelf) GunActions[0].SetActive(true);
                if (RayInstractorObjs[0].activeSelf) RayInstractorObjs[0].SetActive(false);
                _rayInteractor[0].ModeLR = true;
                BulletCountL = 0;
            }

            if (BulletCountR == BulletMaxCount)
            {
                if (!GunActions[1].activeSelf) GunActions[1].SetActive(true);
                if (RayInstractorObjs[1].activeSelf) RayInstractorObjs[1].SetActive(false);
                _rayInteractor[1].ModeLR = false;
                BulletCountR = 0;
            }
        }
    }
}