using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flag : MonoBehaviour
{
        public int flag_count=0;
        string arrow="";
        public float color=0;//初期透明度（透明）
        Text text;
        // Start is called before the first frame update
        void Start()
        {
                //gameObject.GetComponent<Renderer>().material.color=new Color(1,1,1,color);
                //this.color=new Color(0f,0f,0f,0);
                text = this.GetComponent<Text>();
                //text.color = new Color(1.0f, 0.0f, 0.0f, color);
        }

        // Update is called once per frame
        void Update()
        {
                if(color>0) color-=0.01f;
                text.color = new Color(1.0f, 0.0f, 0.0f, color);
                GetComponent<Text>().text = arrow;
                if(flag_count==0) arrow="";
                if(flag_count==1) arrow="←";
                if(flag_count==2) arrow="➡";
                if(flag_count==3) arrow="➡";
                if(flag_count==4) arrow="➡";
        }
}
