using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Button : MonoBehaviour
{
        // Start is called before the first frame update
        public salmon fish;
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
                if(Input.GetKey(KeyCode.Return)) {
                        gameObject.SetActive(false);
                        fish.salmon_flag++;//1で稼働
                        fish.speed=3f;
                        MyCanvas.SetActive("Restart", true);
                }
        }
        public void OnClick()
        {
                //Debug.Log("押された!"); // ログを出力
                gameObject.SetActive(false);
                fish.salmon_flag++;//1で稼働
                fish.speed=3f;
                MyCanvas.SetActive("Restart", true);
        }
}
