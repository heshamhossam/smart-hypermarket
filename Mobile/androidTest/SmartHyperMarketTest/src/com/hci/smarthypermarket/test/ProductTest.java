package com.hci.smarthypermarket.test;

import com.hci.smarthypermarket.Product;

import android.test.AndroidTestCase;

public class ProductTest extends AndroidTestCase {
	
	//Test Product Constructor and its objects
	public void testConstructor()
	{
		Product product = new Product("1", "ahmed", "12345", 10);
		assertNotNull(product);
	}
	
	//Test Product Name
	public void testName()
	{
		Product product = new Product();
		product.setName("ahmed");
		
		String expected = "ahmed";
		String actual = product.getName();
		
		assertEquals(expected, actual);
	}
	
	//Test Product Barcode
	public void testBarcode()
	{
		Product product = new Product();
		product.setBarcode("12345");
		
		String expected = "12345";
		String actual = product.getBarcode();
		
		assertEquals(expected, actual);
		
	}
	
	//Test Total Price of Purchased Produtcs
	public void testTotalPrice()
	{
		Product product = new Product();
		product.setPrice(10);
		product.setPurchasedQuantity(2);
		
		float expected = 20;
		float actual = product.getTotalPrice();
		
		assertEquals(expected, actual);
	}

}
