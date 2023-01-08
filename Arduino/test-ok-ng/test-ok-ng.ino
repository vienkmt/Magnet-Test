
const int RED[18] = {A0,A1,A2,A3,A0,A1,A2,A3,A0,A1,A2,A3,A0,A1,A2,A3,A0,A1};
const int GREEN[18] = {A0,A1,A2,A3,A0,A1,A2,A3,A0,A1,A2,A3,A0,A1,A2,A3,A0,A1};

boolean ok[18];boolean ng[18];
//out 6-13, die 25,28


void setup() {
  //set in
  for (int i = 0; i < 18; i++) {
      pinMode(GREEN[i], INPUT);
      pinMode(RED[i], INPUT);
  }
 // pinMode(LED_BUILTIN_RX, INPUT);
 // pinMode(LED_BUILTIN_TX, INPUT);
  Serial1.begin(9600);
  Serial.begin(9600);

}

void loop() {
  
  String KetQuaOK="";
  String KetQuaNG="";
  //Liên tục đọc Input, ghi vào 2 mảng sau;
  for (int i = 0; i < 18; i++) {
    //sensorVal = digitalRead(RED[i]);
    bool rd = digitalRead(RED[i]);
    bool gr = digitalRead(GREEN[i]);
    //đã đảo bit đi rồi
    if(rd)
      KetQuaNG=KetQuaNG+"0";
    else
      KetQuaNG=KetQuaNG+"1";
    if(gr)
      KetQuaOK=KetQuaOK+"0";
    else
      KetQuaOK=KetQuaOK+"1";
    ok[i]=1;
    ng[i]=1;
  }
  


  String stt="#INIT#";
  //Đã có kết quả OK VÀ NG

  if(KetQuaNG=="000000000000000000" && KetQuaOK=="000000000000000000")
    stt="#WAIT#";
    
  if(KetQuaNG=="000000000000000000" && KetQuaOK=="111111111111111111")
    stt="#OK#";
    
  if(KetQuaNG!="000000000000000000")
    stt="#NG#";
  
  String info="#"+stt+KetQuaOK+"#"+KetQuaNG+"##";
  info="##NG#000000000000000#111111111111111##";
  // gửi lên cho pc kết luận cuối cùng.
  // Chờ cho phiên test tiếp theo
  Serial1.println(info);
  delay(1000);

   info="##WAIT#000000000000000#111111111111111##"; 
  Serial1.println(info);
  delay(1000);

  info="##OK#000000000000000#111111111111111##";
  // gửi lên cho pc kết luận cuối cùng.
  // Chờ cho phiên test tiếp theo
  Serial1.println(info);
  delay(1000);

   info="##WAIT#000000000000000#111111111111111##"; 
  Serial1.println(info);
  delay(1000);


}

/*
  SerialEvent occurs whenever a new data comes in the hardware serial RX. This
  routine is run between each time loop() runs, so using delay inside loop can
  delay response. Multiple bytes of data may be available.
*/

