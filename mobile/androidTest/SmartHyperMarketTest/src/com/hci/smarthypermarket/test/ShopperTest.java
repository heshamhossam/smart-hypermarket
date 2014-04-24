package com.hci.smarthypermarket.test;

import com.hci.smarthypermarket.Order;
import com.hci.smarthypermarket.Product;
import com.hci.smarthypermarket.Shopper;

import android.test.AndroidTestCase;


public class ShopperTest extends AndroidTestCase {
	
	//Test Scanned Product
	public void testScannedProduct()
	{
		Shopper shopper = new Shopper();
		Product product = new Product();
		
		product.setName("ahmed");
		shopper.setScannedProduct(product);
		
		String expected = "ahmed";
		String actual = shopper.getScannedProduct().getName();
		
		assertEquals(expected, actual);
	}
	
	//Test Order Object with Shopper
	public void testOrder()
	{
		Shopper shopper = new Shopper();
		Order order = new Order();
		
		shopper.setOrder(order);
		shopper.getOrder();
		
		assertNotNull(shopper);
	
	}
	
	//Test Market
	public void testMarket()
	{
		Shopper shopper = new Shopper();
		shopper.setMarketId("1");
		
		String expected = "1";
		String actual = shopper.getMarketId();
		
		assertEquals(expected, actual);
	}

}
