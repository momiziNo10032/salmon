using UniRx;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
        // Start is called before the first frame update
        [SerializeField]
        float speed = 1.0f;

        [SerializeField]
        float rotationSpeed = 0.01f;

        [SerializeField]
        float rotation_Interval = 3;

        Rigidbody iwasirigid;
        void Start()
        {
                iwasirigid = GetComponent<Rigidbody>();

                Observable.Timer(TimeSpan.FromSeconds(rotation_Interval))
                .Repeat()
                .Subscribe(_ =>
                {
                        int count = UnityEngine.Random.Range(0, 6);
                        //print(count);
                        if (count == 0)
                        {
                                //左向き、下向きにトルクをかける
                                iwasirigid.AddTorque(Vector3.down * rotationSpeed, ForceMode.Impulse);
                                iwasirigid.AddTorque(Vector3.right * rotationSpeed, ForceMode.Impulse);
                        }
                        else if (count == 1)
                        {
                                //右向き、下向きにトルクをかける
                                iwasirigid.AddTorque(Vector3.up * rotationSpeed, ForceMode.Impulse);
                                iwasirigid.AddTorque(Vector3.right * rotationSpeed, ForceMode.Impulse);

                        }
                        else if (count == 2)
                        {
                                //左向き、上向きにトルクをかける
                                iwasirigid.AddTorque(Vector3.down * rotationSpeed, ForceMode.Impulse);
                                iwasirigid.AddTorque(Vector3.left * rotationSpeed, ForceMode.Impulse);
                        }
                        else if(count == 3)
                        {
                                //右向き、上向きにトルクをかける
                                iwasirigid.AddTorque(Vector3.up * rotationSpeed, ForceMode.Impulse);
                                iwasirigid.AddTorque(Vector3.right * rotationSpeed, ForceMode.Impulse);
                        }
                        else if(count == 4)
                        {
                                //右向きにトルクをかける
                                iwasirigid.AddTorque(Vector3.up * rotationSpeed, ForceMode.Impulse);
                        }
                        else if(count == 5)
                        {
                                //左向きにトルクをかける
                                iwasirigid.AddTorque(Vector3.down * rotationSpeed, ForceMode.Impulse);
                        }
                })
                .AddTo(this);
        }

        // Update is called once per frame
        void Update()
        {
                //前に進む
                iwasirigid.velocity = this.gameObject.transform.forward * speed;

                //外積で元に戻す　X軸方向
                Vector3 left = this.gameObject.transform.TransformVector(Vector3.left);
                Vector3 hori_left = new Vector3(left.x, 0, left.z).normalized;
                iwasirigid.AddTorque(Vector3.Cross(left, hori_left) * 4, ForceMode.Force);

                //外積で元に戻す　Z軸方向
                Vector3 forward = this.gameObject.transform.TransformVector(Vector3.forward);
                Vector3 hori_forward = new Vector3(forward.x, 0, forward.z).normalized;
                iwasirigid.AddTorque(Vector3.Cross(forward, hori_forward) * 4, ForceMode.Force);

        }
        public void Init(){
        }
}
