using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Assets.scripts
{
    class Carta : MonoBehaviour
    {
        public int id;
        public int pos;

        //Front
        public Canvas Canvas;
        public RawImage RawImage;
        public VideoPlayer VideoPlayer;
        public double timer;
        public GameObject ButtonPlay_1;
        public string URL;
        public VideoClip clip;
        //Back
        public Canvas CanvasVerso;
        public RawImage RawImageVerso;
        public VideoPlayer VideoPlayerVerso;
        private GameObject bc;
       



        public Vector3 vector = new Vector3(0, 12, 0);
        public Vector3 vectorRotate = new Vector3();
        public Vector3 vectorImages;


        
        public Boolean Active;
        Boolean Pressed = false;
        public Boolean PressedOne = false;
        Boolean ShowPressed = false;
        public Color Color;


        //SRS
        public int Interval;
        public double EasyFactor;
        public int Repetitions;
        public DateTime ReviewDate;
        public string TextView;
        public string TextViewResponse;

        public Carta()
        {          
            RawImage.gameObject.SetActive(false);    
        }




        private void Start()
        {
            RawImage.gameObject.SetActive(false);  
            bc = GameObject.Find("Baralho");
            
        }


        private void Update()
        {

            if (VideoPlayer.isPaused)
            {
                RawImage.gameObject.SetActive(false);
            }
            gameObject.transform.position = vector;
            gameObject.GetComponent<MeshRenderer>().material.color = Color;

        //isActiveOnScene(Active);   
        }



        public void isActiveOnScene(bool a)
        {
            gameObject.SetActive(a);
        }



        public void IsPressed()
        {

            if (!Pressed)
            {
                StartCoroutine(PlayVideo());                
            }
            else
            {
                VideoPlayer.Stop();
                Pressed = false;
            }

            
        }


        public void ShowResponseIsPressed()
        {
            if (!Pressed)
            {
                gameObject.transform.Rotate(vectorRotate);
                Pressed = true;
            }
            else
            {
                Pressed = false;
            }
        }  

        
        public void NextResponseIsPressed()
        {
            var BcControl = bc.GetComponent<Baralho>();
            BcControl.LogInform(pos);
        }  


        public void ResponseOneIsPressed()
        {
            if (!Pressed)
            {
               // gameObject.SetActive(false);
                PressedOne = true;
            }
            else
            {
                PressedOne = false;
            }
        }



        public IEnumerator PlayVideo()
        {
            VideoPlayer.url = URL;
            RawImage.gameObject.SetActive(true);
            VideoPlayer.Prepare();
            WaitForSeconds waitForSeconds = new WaitForSeconds(1);
            while (!VideoPlayer.isPrepared)
            {
                yield return waitForSeconds;
                break;
            }
            RawImage.texture = VideoPlayer.texture;
            VideoPlayer.Play();
                        
        }

    }
}