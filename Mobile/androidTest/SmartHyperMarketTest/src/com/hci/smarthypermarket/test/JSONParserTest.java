package com.hci.smarthypermarket.test;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONObject;

import com.hci.smarthypermarket.models.JSONParser;
import com.hci.smarthypermarket.models.Model;

import android.test.AndroidTestCase;


public class JSONParserTest extends AndroidTestCase {
	public void testConstructor()
	 {
	 		JSONParser json = new JSONParser();
	 		assertNotNull(json);
	 }
	
	public void testJsonRequest(){
		  	
			 	  JSONParser json = new JSONParser();
			      String url_product_detials = Model.linkServiceRoot+"/products/retrieve";
 			  	  List<NameValuePair> CParams = new ArrayList<NameValuePair>();
 			 	  CParams.add(new BasicNameValuePair("barcode","1234"));
			 	  CParams.add(new BasicNameValuePair("market_id","1"));
 			 	  JSONObject jsonn = json.makeHttpRequest(url_product_detials,"GET", CParams);
 			      String s = jsonn.toString();
 			      assertEquals(s.contains("No Product with the given barcode 1234"), true);
 		    }
 	  public void testJsonRequest2()
 	  {
 		  JSONParser json = new JSONParser();
 	      String url_product_detials = Model.linkServiceRoot+"/products/retrieve";
 	  	  List<NameValuePair> CParams = new ArrayList<NameValuePair>();
 	 	  CParams.add(new BasicNameValuePair("barcode","23456789"));
 	 	  CParams.add(new BasicNameValuePair("market_id","1"));
 	 	  JSONObject jsonn = json.makeHttpRequest(url_product_detials,"GET", CParams);
 	      String s = jsonn.toString();
 	      assertEquals(s.contains("success"), true);
 	  }
 
 }