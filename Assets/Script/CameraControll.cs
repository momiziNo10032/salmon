using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
        // Start is called before the first frame update
        public static CameraControll m_instance;

        private Vector3 cameraplayer_position;
        private Vector3 cameraplayer_forward;
        private Vector3 cameraplayer_rotate;
        public float distance=10f;  //最大スケール

        Vector3 camera_pos;
        Quaternion camera_rotate;
        public float zposition=-10f;
        public float yposition=2f;
        void Start()
        {
                m_instance=this;
        }

        // Update is called once per frame
        void Update()
        {
                //camera_pos=salmon.m_instance.transform.position;
                //camera_rotate=salmon.m_instance.transform.rotation;
                cameraplayer_position=salmon.m_instance.transform.position;//自機のポジション
                cameraplayer_forward=salmon.m_instance.transform.forward;//自機のベクトル
                cameraplayer_rotate=salmon.m_instance.transform.localEulerAngles;//自機の傾き
                cameraplayer_rotate.z=0;
                var camerapos =cameraplayer_position-cameraplayer_forward*distance;
                camerapos.y=yposition;
                //camerapos.y=Mathf.Round(camerapos.y);//四捨五入
                //print(cameraplayer_position);
                transform.position =camerapos;
                transform.localEulerAngles=cameraplayer_rotate;
                //camera_pos.z+=zposition;
                //camera_pos.y+=ypositoon;
                // transform.position=camera_pos;
                // transform.rotation=camera_rotate;
        }
}
