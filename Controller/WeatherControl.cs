using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeatherControl : MonoBehaviour {

    public string City;
    public string Temperature;
    public string Humidity;
    public string Clouds;
    public string WeatherCode;
    public string WeatherDescription;

    public RainControl RainControl;
    public CloudControl CloudControl;
    public SnowControl SnowControl;
    public LightningControl LightningControl;
    public GroundFogControl GroundFogControl;

    public int LightRain;
    public int MediumRain;
    public int HeavyRain;
    public int extremeRain;

    public int LightSnow;
    public int MediumSnow;
    public int HeavySnow;
    public int ExtremeSnow;

    public Text TextCity;
    public Text TextDescription;
    public Text TextTemperature;


    void Start () {

        TextCity = GameObject.Find("NameCity").GetComponent<Text>();
        TextDescription = GameObject.Find("textDescription").GetComponent<Text>();
        TextTemperature = GameObject.Find("textTemperature").GetComponent<Text>();

        RainControl = GameObject.Find("_Rain").GetComponent<RainControl>();
        CloudControl = GameObject.Find("_Cloud").GetComponent<CloudControl>();
        SnowControl = GameObject.Find("_Snow").GetComponent<SnowControl>();
        LightningControl = GameObject.Find("_Lightning").GetComponent<LightningControl>();
        GroundFogControl = GameObject.Find("_GroundFog").GetComponent<GroundFogControl>();
       
        //Default value
        City = "default" ;
        Temperature = "10";
        Humidity = "0";
        Clouds = "10";
        WeatherCode = "800";
        WeatherDescription = "No Connection";  
    }

    public void ResetFunction()
    {
        RainControl.SendMessage("stop");
        CloudControl.SendMessage("stop");
        SnowControl.SendMessage("stop");
        LightningControl.SendMessage("stop");
        GroundFogControl.SendMessage("stop");
    }

    public void makeWeather(){
        ResetFunction();
        ReadWeatherCode();
        TextCity.text = City;
        TextDescription.text =  WeatherDescription;
       // convert string in a flout to round the value
        TextTemperature.text = Mathf.Round(float.Parse(Temperature)).ToString() + " C";
    }


    public void makeRain() {
        ResetFunction();
        TextCity.text = "";
        TextDescription.text = "heavy intensity rain ";
        TextTemperature.text = "";
        RainControl.SendMessage("activated", HeavyRain);
        CloudControl.SendMessage("activated", 50);
    }
    public void makeSnow(){
        ResetFunction();
        TextCity.text = "";
        TextDescription.text = "heavy snow";
        TextTemperature.text = "";
        SnowControl.SendMessage("activated", HeavySnow);
        CloudControl.SendMessage("activated", 50);

    }
    public void makeTunder() {
        ResetFunction();
        TextCity.text = "";
        TextDescription.text = "thunderstorm with light drizzle ";
        TextTemperature.text = "";
        LightningControl.SendMessage("activated");
        CloudControl.SendMessage("activated", 50);
        RainControl.SendMessage("activated", LightRain);
    }

    public void makeClear() {
        ResetFunction();
        TextCity.text = "";
        TextDescription.text = "clear sky ";
        TextTemperature.text = "";
    }

    public void makeFog()
    {
        ResetFunction();
        TextCity.text = "";
        TextDescription.text = "mist";
        TextTemperature.text = "";
        GroundFogControl.SendMessage("activated");
        
    }
    public void makeClouds()
    {
        ResetFunction();
        TextCity.text = "";
        TextDescription.text = "broken clouds";
        TextTemperature.text = "";
        CloudControl.SendMessage("activated", 50);
    }
    public void ReadWeatherCode()
    {
        if (WeatherCode == "200") { // thunderstorm with light rain  
            RainControl.SendMessage("activated", LightRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
            LightningControl.SendMessage("activated");
        }
        if (WeatherCode == "201"){ //  thunderstorm with rain     
            RainControl.SendMessage("activated", MediumRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
            LightningControl.SendMessage("activated");
        }
        if (WeatherCode == "202"){//      thunderstorm with heavy rain 
            RainControl.SendMessage("activated", extremeRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
            LightningControl.SendMessage("activated");
        }
        if (WeatherCode == "210"){//      light thunderstorm
            CloudControl.SendMessage("activated", int.Parse(Clouds));
            LightningControl.SendMessage("activated");
        }
        if (WeatherCode == "211"){//     //thunderstorm}
            CloudControl.SendMessage("activated", int.Parse(Clouds));
            LightningControl.SendMessage("activated");
        }
        if (WeatherCode == "212"){//      heavy thunderstorm
            CloudControl.SendMessage("activated", int.Parse(Clouds));
            LightningControl.SendMessage("activated");
        }
        if (WeatherCode == "221"){//     ragged thunderstorm
            CloudControl.SendMessage("activated", int.Parse(Clouds));
            LightningControl.SendMessage("activated");
            RainControl.SendMessage("activated", extremeRain);
        }
        if (WeatherCode == "230"){//      thunderstorm with light drizzle
            SnowControl.SendMessage("activated", LightSnow);
            RainControl.SendMessage("activated", LightRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
            LightningControl.SendMessage("activated");
        }
        if (WeatherCode == "231"){//     thunderstorm with drizzle
            SnowControl.SendMessage("activated", LightSnow);
            RainControl.SendMessage("activated", LightRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
            LightningControl.SendMessage("activated");
        }
        if (WeatherCode == "232"){// thunderstorm with heavy drizzle
            SnowControl.SendMessage("activated", HeavySnow);
            RainControl.SendMessage("activated", HeavyRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
            LightningControl.SendMessage("activated");
        }
        if (WeatherCode == "300"){//          light intensity drizzle
            SnowControl.SendMessage("activated", LightSnow);
            RainControl.SendMessage("activated", LightRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "301"){//     drizzle
            SnowControl.SendMessage("activated", LightSnow);
            RainControl.SendMessage("activated", LightRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "302"){// heavy intensity drizzle
            SnowControl.SendMessage("activated", LightSnow);
            RainControl.SendMessage("activated", LightRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "310"){//light intensity drizzle rain
            SnowControl.SendMessage("activated", LightSnow);
            RainControl.SendMessage("activated", LightRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "311"){//drizzle rain
            SnowControl.SendMessage("activated", LightSnow);
            RainControl.SendMessage("activated", LightRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "312"){//heavy intensity drizzle rain
            SnowControl.SendMessage("activated", LightSnow);
            RainControl.SendMessage("activated", LightRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "313"){//shower rain and drizzle
            SnowControl.SendMessage("activated", LightSnow);
            RainControl.SendMessage("activated", LightRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "314"){//heavy shower rain and drizzle
            SnowControl.SendMessage("activated", LightSnow);
            RainControl.SendMessage("activated", LightRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "321"){//shower drizzle
            SnowControl.SendMessage("activated", LightSnow);
            RainControl.SendMessage("activated", LightRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "500"){//light rain
            RainControl.SendMessage("activated", LightRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "501"){//moderate rain
            RainControl.SendMessage("activated", MediumRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "502"){//heavy intensity rain
            RainControl.SendMessage("activated", HeavyRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "503"){//very heavy rain
            RainControl.SendMessage("activated", extremeRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "504"){//extreme rain
            RainControl.SendMessage("activated", extremeRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "511"){//freezing rain
            SnowControl.SendMessage("activated", MediumSnow);
            RainControl.SendMessage("activated", MediumRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "520"){//light intensity shower rain
            RainControl.SendMessage("activated", MediumRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "521"){//shower rain
            RainControl.SendMessage("activated", MediumRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "522"){//heavy intensity shower rain
            RainControl.SendMessage("activated", extremeRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "531"){//ragged shower rain
            RainControl.SendMessage("activated", MediumRain);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "600"){//light snow
            SnowControl.SendMessage("activated", LightSnow);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "601"){//snow
            SnowControl.SendMessage("activated", MediumSnow);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "602"){//heavy snow
            SnowControl.SendMessage("activated", HeavySnow);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "611"){// sleet
            SnowControl.SendMessage("activated", HeavySnow);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "612"){// shower sleet
            RainControl.SendMessage("activated", LightRain);
            SnowControl.SendMessage("activated", MediumSnow);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "615"){// light rain and snow
            RainControl.SendMessage("activated", LightRain);
            SnowControl.SendMessage("activated", MediumSnow);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "616"){//rain and snow
            RainControl.SendMessage("activated", MediumSnow);
            SnowControl.SendMessage("activated", MediumSnow);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "620"){//light shower snow
            RainControl.SendMessage("activated", MediumSnow);
            SnowControl.SendMessage("activated", MediumSnow);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "616"){//rain and snow
            RainControl.SendMessage("activated", MediumSnow);
            SnowControl.SendMessage("activated", MediumSnow);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "621") {//     shower snow
            RainControl.SendMessage("activated", MediumSnow);
            SnowControl.SendMessage("activated", MediumSnow);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "622")        {//     heavy shower snow
            RainControl.SendMessage("activated", MediumSnow);
            SnowControl.SendMessage("activated", MediumSnow);
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "701") {//     mist
            GroundFogControl.SendMessage("activated");


        }
        if (WeatherCode == "711")
        {//     smoke
        
        }
        if (WeatherCode == "721")
        {//     haze
   
        }

        if (WeatherCode == "731")
        {//     sand, dust whirls]

        }
        if (WeatherCode == "741")
        {//     fog


        }
        if (WeatherCode == "751")
        {//     sand

        }
        if (WeatherCode == "761")
        {//     dust

        }
        if (WeatherCode == "762")
        {//     volcanic ash
     
        }
        if (WeatherCode == "771")
        {//     squalls
        }
        if (WeatherCode == "781")
        {//     tornado
        }

        if (WeatherCode == "800")
        {//     clear sky

        }
        if (WeatherCode == "801")
        {//     few clouds
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "803")
        {//     broken clouds
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "804")
        {//     overcast clouds
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "900")
        {//     tornado
            CloudControl.SendMessage("activated", int.Parse(Clouds));
        }
        if (WeatherCode == "901")
        {//     tropical storm
        }
        if (WeatherCode == "902")
        {//     hurricane
        }
        if (WeatherCode == "903")
        {//     cold
        }
        if (WeatherCode == "904")
        {//     hot
        }
        if (WeatherCode == "905")
        {//     windy
        }
        if (WeatherCode == "906")
        {//     hail
        }
        if (WeatherCode == "951")
        {//     calm
        }
        if (WeatherCode == "952")
        {//     light breeze
        }
        if (WeatherCode == "953")
        {//     gentle breeze
        }
        if (WeatherCode == "954")
        {//     moderate breeze
        }
        if (WeatherCode == "955")
        {//     fresh breeze
        }
        if (WeatherCode == "956")
        {//     strong breeze
        }
        if (WeatherCode == "957")
        {//     high wind, near gale
        }
        if (WeatherCode == "958")
        {//     gale
        }
        if (WeatherCode == "959")
        {//     severe gale
        }
        if (WeatherCode == "960")
        {//     storm
        }
        if (WeatherCode == "961")
        {//     violent storm
        }
        if (WeatherCode == "962")
        {//     hurricane
        }

    }

}
