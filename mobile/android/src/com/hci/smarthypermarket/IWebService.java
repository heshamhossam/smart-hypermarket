package com.hci.smarthypermarket;

import android.location.Location;

public interface IWebService {
	
	//get Product Object
	//@barcode: string contains the bar code to request data from server by it
	void getProduct(String barcode);
	
	//get Market object
	//@location: location to search the market at
	void getMarket(Location location);
	
	
	
	

}
