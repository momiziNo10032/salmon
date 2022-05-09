using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
        public salmon fish;
        public Flag flag;
        // Start is called before the first frame update
        void Start()
        {
                gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void OnClick() {
                Debug.Log("Button2 click!");
                // 非表示にする
                fish.salmon_flag++;
                fish.gameObject.SetActive(true);//salmon display
                fish.speed=0.000f;//salmon stop
                fish.transform.position=new Vector3(-67f,0.312f,-30.5f);//back start
                fish.inclination=0f;
                fish.sau=90f;
                gameObject.SetActive(false);//This yyyyyButton false
                flag.flag_count=0;
                // Buttonを表示する
                MyCanvas.SetActive("Start_Button", true);
        }
}
