package com.hci.smarthypermarket.test;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONObject;

import com.hci.smarthypermarket.JSONParser;

import android.test.AndroidTestCase;

public class JSONParserTest extends AndroidTestCase {
	
	public void testConstructor()
	{
		JSONParser json = new JSONParser();
		assertNotNull(json);
	}
   public void testJsonRequest(){
	 JSONParser json = new JSONParser();
     String url_product_detials = "http://zonlinegamescom.ipage.com/smarthypermarket/public/products/retrieve";
 	 List<NameValuePair> CParams = new ArrayList<NameValuePair>();
	 CParams.add(new BasicNameValuePair("barcode","1234"));
	 CParams.add(new BasicNameValuePair("market_id","1"));
	 JSONObject jsonn = json.makeHttpRequest(url_product_detials,"GET", CParams);
     String s = jsonn.toString();
     assertEquals(s.contains("1234"), true);

   }
}
