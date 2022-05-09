using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
        // Start is called before the first frame update
        private Vector3 player_position;
        private Vector3 player_forward;
        private Vector3 player_rotate;
        public static Explosion megumin;
        void Start()
        {
                megumin=this;
                this.GetComponent<ParticleSystem>().Stop();
        }

        // Update is called once per frame
        void Update()
        {
                player_position=salmon.m_instance.transform.position;//自機のポジション
                player_forward=salmon.m_instance.transform.forward;                    //自機ののベクトル
                player_rotate=salmon.m_instance.transform.localEulerAngles;//自機の傾き
                player_position.y+=0.5f;
                transform.position =player_position;
        }
}
