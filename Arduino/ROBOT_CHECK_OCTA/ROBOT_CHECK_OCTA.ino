#include<string.h>

#define SENSOR A1
#define LOA    12
#define CV     11

String ON_SPK = "ON_SPK";
String OFF_SPK = "OFF_SPK";
String READ_STATUS = "READ_STT";
String CV_ON =      "CV_ON";
String CV_OFF =      "CV_OFF";

String ON_SPK_OK = "ON_SPK_OK\r\n";
String OFF_SPK_OK = "OFF_SPK_OK\r\n";
String SENSOR_ON = "SENSOR_ON\r\n";
String SENSOR_OFF = "SENSOR_OFF\r\n";

String CV_ON_OK = "CV_ON_OK\r\n";
String CV_OFF_OK = "CV_OFF_OK\r\n";

void setup() {
 Serial1.begin(9600);
 Serial1.setTimeout(40);
 pinMode(SENSOR,INPUT_PULLUP);
 pinMode(CV,OUTPUT);
 pinMode(LOA,OUTPUT);
 digitalWrite(LOA,LOW);
 digitalWrite(CV,HIGH);
}

void loop() {

  if(Serial1.available() > 0)
  {
      String INP = Serial1.readString();   // Read 
      
          String STR_1 = INP.substring(0,6);
          String STR_2 = INP.substring(0,7);
          String STR_3 = INP.substring(0,8);
          String STR_4 = INP.substring(0,5);
          
          
     if(STR_1.compareTo(ON_SPK) == 0)
    {
      
      digitalWrite(LOA,HIGH);
      Serial1.print(ON_SPK_OK);
    }
    else if(STR_2.compareTo(OFF_SPK) == 0)
    {   
      digitalWrite(LOA,LOW);
      Serial1.print(OFF_SPK_OK);
    }
     else if(STR_4.compareTo(CV_ON) == 0)
     {
       digitalWrite(CV,HIGH);
       Serial1.print(CV_ON_OK);
     }
     else if(STR_1.compareTo(CV_OFF) == 0)
     {
        digitalWrite(CV,LOW);
        Serial1.print(CV_OFF_OK);
     }


    if(STR_3.compareTo(READ_STATUS) == 0)
    {
      if(digitalRead(SENSOR) == 1)
        {            
        Serial1.print(SENSOR_ON);      
        }
      else
       {
        Serial1.print(SENSOR_OFF);        
       }
    }
   }
}
