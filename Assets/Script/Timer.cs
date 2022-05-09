﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
        // Start is called before the first frame update
        public float countTime = 0;
        public bool timer=false;
        void Start()
        {
                GetComponent<Text>().text = countTime.ToString("F2");//小数2桁にして表示
        }

        // Update is called once per frame
        void Update()
        {
                if(timer==true) {
                        countTime += Time.deltaTime; //スタートしてからの秒数を格納
                }
                GetComponent<Text>().text = countTime.ToString("F2"); //小数2桁にして表示
        }
}
