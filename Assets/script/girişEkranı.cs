using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class giri�Ekran� : MonoBehaviour
{
    public GameObject cikisEkrani;

    private void Start()
    {
        // bu i�lemi yaparak oyun ekran�ndan ana ekrana d�n�nce time.timeScale 0 olarak kald��� i�in oyun �al��maz bunu d�zeltip bug a sokmaktan kurtard�k
        if(Time.timeScale==0)
        {
            Time.timeScale = 1;
        }
    }
    public void oyundan��k()
    {
        cikisEkrani.SetActive(true);
        
    }
    public void cevap(string cevap)
    {
        if (cevap == "evet")
        {
            Application.Quit();
        }
        else
        {
            cikisEkrani.SetActive(false);
        }
    
    }
    public void oyunaBa�la()
    {
        SceneManager.LoadScene(1);
    }
}
