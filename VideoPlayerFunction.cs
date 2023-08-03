using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerFunction : MonoBehaviour
{
    public VideoPlayer videoPlayer; //Initialise Videoplayer variable
    public VideoClip[] videoClips;  //Initialise Videoclips
    public GameObject[] videoButtons;   //Initialise 3 Buttons for 3 videos
    public GameObject pauseButton, playButton, backButton, seekBack, seekForward, galleryButton, videoPlayerObject, powerButton, tvObject;
    // Initialise all buttons for video player control

    private bool isPaused = false;  //boolean to check if video is playing or notc
    private bool isOn = false; //boolean to check if TV is on or not
    
    
    // Start is called before the first frame update
    void Start()                                //Deactivating all objects other than Power button at the start of the app
    {
        powerButton.SetActive(true);
        galleryButton.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        videoPlayerObject.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        seekBack.SetActive(false);
        seekForward.SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            videoButtons[i].gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Seek(float time)    //Function to seek video
    {
        videoPlayer.time += time;
    }
    
    public void playVideo1()    //Function for video 1 button (Play 3rd Video)
    {
        videoPlayerObject.gameObject.SetActive(true); 
        videoPlayer.clip = videoClips[0];
        videoPlayer.Play();
        isPaused = false;
        pauseButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
    }
    public void playVideo2()         //Function for video 2 button (Play 2nd video)
    {
        videoPlayerObject.gameObject.SetActive(true);
        videoPlayer.clip = videoClips[1];
        videoPlayer.Play();
        isPaused = false;
        pauseButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
    }
    public void playVideo3()        //Function for video 3 button (Play 3rd video)
    {
        videoPlayerObject.gameObject.SetActive(true);
        videoPlayer.clip = videoClips[2];
        videoPlayer.Play();
        isPaused = false;
        pauseButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
    }

    public void SeekForward()       //Function for Seek forward button (Seek 5 secs forward)
    {
        Seek(5f);
    }

    public void SeekBackward()      //Function for Seek backward button (seek 5 secs backward)
    {
         Seek(-5f);
    }
    public void PlayButton()        //Function for play/pause button (check if video is playing and play/pause accordingly. Also hide/show play/pause button)
    {
        if (isPaused)
        {
            videoPlayer.Play();
            isPaused = false;
            pauseButton.gameObject.SetActive(true);
            playButton.gameObject.SetActive(false);
        }
        else
        {
            videoPlayer.Pause();
            isPaused = true;
            pauseButton.gameObject.SetActive(false);
            playButton.gameObject.SetActive(true);
        }
    }

    
    public void VideoButton()       //Function for all Video buttons (Show video controls and hide video buttons)
    {
        for (int i = 0; i < 3; i++) 
        {
            videoButtons[i].gameObject.SetActive(false);
        }
        backButton.SetActive(true);
        seekForward.SetActive(true);
        seekBack.SetActive(true);
    }

    public void BackButton()        //Function for back button (Show video buttons and hide video player controls)
    {
        videoPlayerObject.gameObject.SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            videoButtons[i].gameObject.SetActive(true);
        }
        videoPlayer.Stop();
        backButton.SetActive(false);
        seekForward.SetActive(false);
        seekBack.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
    }

    public void GalleryButtonpress()        //Function for Gallery button (Show video buttons and hide gallery button)
    {
        for (int i = 0; i < 3; i++)
        {
            videoButtons[i].gameObject.SetActive(true);
        }
        galleryButton.SetActive(false);
    }

    public void PowerButton()       //Function for power button (Checks if TV is on or off)
    {
        if (isOn)
        {
            tvObject.SetActive(false);
            isOn = false;

        }
        else
        {
            tvObject.SetActive(true);
            galleryButton.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            playButton.gameObject.SetActive(false);
            videoPlayerObject.gameObject.SetActive(false);
            backButton.gameObject.SetActive(false);
            seekBack.SetActive(false);
            seekForward.SetActive(false);
            for (int i = 0; i < 3; i++)
            {
                videoButtons[i].gameObject.SetActive(false);
            }
            isOn = true;
        }
    }
}
