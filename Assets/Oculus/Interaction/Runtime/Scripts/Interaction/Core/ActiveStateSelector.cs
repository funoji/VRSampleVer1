/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using UnityEngine;
using UnityEngine.Assertions;
using Oculus.Interaction;

namespace Oculus.Interaction
{
    public class ActiveStateSelector : MonoBehaviour, ISelector
    {
        [SerializeField] GameObject shotpoint;
        [SerializeField] GameObject bullet;
        [SerializeField] float bulletSpeed = 10f;
        [Tooltip("ISelector events will be raised " +
            "based on state changes of this IActiveState.")]
        [SerializeField, Interface(typeof(IActiveState))]
        private UnityEngine.Object _activeState;
        protected IActiveState ActiveState { get; private set; }
        
        private bool _selecting = false;

        public event Action WhenSelected = delegate { };
        public event Action WhenUnselected = delegate { };

        int Bulletcount = 0;

        [SerializeField] GameObject SuikomiObj;

        protected virtual void Awake()
        {
            ActiveState = _activeState as IActiveState;
        }

        protected virtual void Start()
        {
            this.AssertField(ActiveState, nameof(ActiveState));
        }

        protected virtual void Update()
        {
            Debug.Log("Phase1");
            if (_selecting != ActiveState.Active)
            {           
                _selecting = ActiveState.Active;

                if (_selecting && Bulletcount > 0)
                {
                    Debug.Log("Phase2");
                    GameObject NewObj = Instantiate(bullet, shotpoint.GetComponent<Transform>().position, Quaternion.Euler(shotpoint.transform.eulerAngles));
                    NewObj.GetComponent<Rigidbody>().velocity = shotpoint.transform.forward * bulletSpeed;
                    Bulletcount--;
                    WhenSelected();
                }
                else
                {
                    Debug.Log("Phase3");
                    WhenUnselected();
                }
            }

            if(Bulletcount == 0)
            {
                Debug.Log("Phase4");
                //if (gameObject.activeSelf) gameObject.SetActive(false);
                if (!SuikomiObj.activeSelf) SuikomiObj.SetActive(true);
            }
        }
        public int getbullet()
        {
            return Bulletcount;
        }

        public voidÅ@ReloadBullet()
        {
            Bulletcount = 3;
        }

        #region Inject

        public void InjectAllActiveStateSelector(IActiveState activeState)
        {
            InjectActiveState(activeState);
        }

        public void InjectActiveState(IActiveState activeState)
        {
            _activeState = activeState as UnityEngine.Object;
            ActiveState = activeState;
        }
        #endregion
    }
}
