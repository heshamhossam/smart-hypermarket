package com.hci.smarthypermarket.test;

import com.hci.smarthypermarket.Order;
import com.hci.smarthypermarket.Product;
import com.hci.smarthypermarket.Shopper;

import android.test.AndroidTestCase;


public class ShopperTest extends AndroidTestCase {
	
	public void TestScannedProduct()
	{
		Shopper shopper = new Shopper();
		Product product = new Product();
		
		product.setName("ahmed");
		shopper.setScannedProduct(product);
		
		String expected = "ahmed";
		String actual = shopper.getScannedProduct().getName();
		
		assertEquals(expected, actual);
	}
	
	public void TestOrder()
	{
		Shopper shopper = new Shopper();
		Order order = new Order();
		
		shopper.setOrder(order);
		shopper.getOrder();
		
		assertNotNull(shopper);
	
	}

}
