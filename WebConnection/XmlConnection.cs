using UnityEngine;
using System.Collections;
using System.Xml;
using System;
using UnityEngine.UI;


public class XmlConnection : MonoBehaviour{
    WeatherControl WeatherControl;

    public string[] CityNames = { "Amsterdam,nl", "London","Berlin", "Paris","Dublin", "Stockholm", "Beijing", "NewYork", "Sydney" };
    public int count = 0;


    void Start() {
        StartCoroutine(GetData());
    }
    public void Exit()
    {
        Application.Quit();

    }
    public void ChangeCity()
    {
        if (count < (CityNames.Length - 1))
        {
            count++;
        }
        else
        {
            count = 0;
        }
        StartCoroutine(GetData());

    }




    // Update is called once per frame
    IEnumerator GetData()
    {
        WeatherControl = GameObject.Find("weatherSystemPartical").GetComponent<WeatherControl>();

        string url;

        url = "http://api.openweathermap.org/data/2.5/find?q=" + CityNames[count] +"&type=accurate&mode=xml&units=metric&appid=5dc40accf62128dca14eeec836347598";

        WWW www = new WWW(url);

        yield return www;
        if (www.error == null)
        {
           // Debug.Log("Loaded following XML " + www.text);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(www.text);

            WeatherControl.City = xmlDoc.SelectSingleNode("cities/list/item/city/@name").InnerText;
            WeatherControl.Temperature = xmlDoc.SelectSingleNode("cities/list/item/temperature/@value").InnerText;
            WeatherControl.Humidity = xmlDoc.SelectSingleNode("cities/list/item/humidity /@value").InnerText;
            WeatherControl.Clouds = xmlDoc.SelectSingleNode("cities/list/item/clouds/@value").InnerText;
            WeatherControl.WeatherDescription = xmlDoc.SelectSingleNode("cities /list/item/weather/@value").InnerText;
            WeatherControl.WeatherCode = xmlDoc.SelectSingleNode("cities /list/item/weather/@number").InnerText;

            WeatherControl.SendMessage("makeWeather");
  
        }
        else
        {
            Debug.Log("ERROR: " + www.error);

        }

    }
}
