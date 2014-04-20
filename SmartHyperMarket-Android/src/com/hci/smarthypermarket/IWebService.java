package com.hci.smarthypermarket;

public interface IWebService {
	
	//get Product Object
	//@barcode: string contains the bar code to request data from server by it
	void getProduct(String barcode);

}
