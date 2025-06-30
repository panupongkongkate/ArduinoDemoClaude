const int LedPin = 13;  
int ledState = 0;  
  
void setup()  
{   
  pinMode(LedPin, OUTPUT);  
    
  Serial.begin(9600);    
}  
  
void loop()  
{  
  if (Serial.available() > 0)  
  {  
    char receivedChar = Serial.read();  
      
    if (receivedChar == '1')  
    {  
      digitalWrite(LedPin, HIGH);  
      ledState = 1;  
    }  
    else if (receivedChar == '0')  
    {  
      digitalWrite(LedPin, LOW);   
      ledState = 0;  
    }  
  }  
}